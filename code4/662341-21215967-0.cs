    namespace GOCApi.Controllers
    {
        [RoutePrefix("Courses")]
        public class CoursesController : ApiController
        {
            private ICoursesRepository _coursesRepository { get; set; }
    
            public CoursesController(ICoursesRepository coursesRepository)
            {
                _coursesRepository = coursesRepository;
            }
    
            [GET("{id}")]
            public HttpResponseMessage Get(int id)
            {
                var course = _coursesRepository.GetSingle(id);
                if (course == null){
                   return this.Request.CreateResponse(HttpStatusCode.NotFound, "Invalid ID");
                }
                return this.Request.CreateResponse(HttpStatusCode.OK, course);
            }
        }
    }
