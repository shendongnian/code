    // Definition of the factory in the UI or BL layer
    public interface ISomeServiceFactory
    {
        ISomeService Create(int inputParameter);
    }
    // Controller depending on that factory:
    public class MyController : Controller
    {
        private readonly ISomeServiceFactory factory;
        public MyController(ISomeServiceFactory factory)
        {
            this.factory = factory;
        }
        public ActionResult Index(int value)
        {
            // here we use that factory
            var service = this.factory.Create(value);
        }
    }
