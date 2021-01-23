    //This could be in your home controller
    
    public class HomeController : AsyncController
    {
        private IService DBOneService;
        private IService DBTwoService;
        private IService DBThreeService;
       public HomeController(IService one, IService two, IService three)
       {
          DBOneService= one;
          DBTwoService = two;
          DBThreeService = three;
       }
      public HomeController() : this(new DBServiceOne(), new DBServiceTwo(), new DBServiceThree()) {}
    public ActionResult Index() {
       DBOneService.DoStuff(); //here you'd want to return a list of data and serialize down with json or populate your razor template with it. Hope this helps!
    
    }
