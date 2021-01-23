    public class SomeController: Controller
    {
        private readonly IMyFactory factory;  
        public SomeController(IMyFactory factory)
        {
            this.factory = factory;
        }
    
        public ActionResult SomeAction()
        {
            var domainModel = this.factory.ConstructDomainObject(Request.Params);
            ...
        }
    }
