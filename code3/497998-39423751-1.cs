    namespace KhandalVipra.Controllers
    {
        [RoutePrefix("api/Profiles")]
        public class ProfilesController : ApiController
        {
            // POST: api/Profiles/LikeProfile
            [Authorize]
            [HttpPost]
            [Route("LikeProfile")]
            [ResponseType(typeof(List<Like>))]
            public async Task<IHttpActionResult> LikeProfile()
            {
            }
        }
    }
