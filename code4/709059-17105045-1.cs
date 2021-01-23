    public class MyAppController : Controller
    {
        protected IUnitOfWork UoW { get; private set; }
    
        public MyAppController(IUnitOfWork uow) 
        {
            this.UoW = uow;
        }
    }
