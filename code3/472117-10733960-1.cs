    public class MyBaseController : Controller 
    {
        public MyBaseController(IMyServiceContainer container) 
        {
            Container = container;
        }
    
        protected IMyServiceContainer Container { get; private set; }
    }
