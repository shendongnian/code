    public class MyModule : NancyModule
    {
      public MyModule()
      {
        Get["/"] =_ => 
          Request.Headers["X-Forwarded-For"].Any() ? HttpStatusCode.OK :
                                                     HttpStatusCode.BadRequest;
      }
    }
