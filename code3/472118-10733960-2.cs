    public class MyController : MyBaseController 
    {
        public MyController(IMyServiceContainer container) : base(container) 
        {
        }
    
        public ActionResult MyAction() 
        {
            Container.MyService1.DoSomething();
            Container.MyService2.DoSomethingElse();
            return View();
        }
    }
