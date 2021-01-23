    public class MyController : Controller
    {
       private IServiceThatINeed _serviceThatINeed;
       public MyController(IServiceThatINeed serviceThatINeed)
       { 
           _serviceThatINeed = _serviceThatINeed;
       }
    }
