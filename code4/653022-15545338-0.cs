    public class TermbaseFilePostDto
    {
        // relevant properties go here
    }
  
    public class TestController : ApiController
    {
         public HttpResponseMessage Post(List<TermbaseFileDto> list)
         {
             ...
         }
    }
