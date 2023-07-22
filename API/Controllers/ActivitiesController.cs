using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext context;

        public ActivitiesController(DataContext dataContext)
        {
            this.context = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            List<Activity> res = await this.context.Activities.ToListAsync();
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetActivity(Guid id)
        {
            var res = await context.Activities.FindAsync(id);
            return Ok(res);
        }
    }
}
