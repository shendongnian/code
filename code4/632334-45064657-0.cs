    public class HomeController : BaseController
    {
       public IHttpActionResult Get()
       {
                base.InitialiseUserState();
                var info = Info;
                    return Ok(info);
            }
    }
     
    public class BaseController : ApiController
        {
            public string Info { get; set; }
            public void InitialiseUserState()
            {
                Info = "test";
            }
        }
