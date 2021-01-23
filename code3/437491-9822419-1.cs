    public class DelinquentAccountsController : Controller
    {
         protected ICommandProvider CommandProvider { get; private set; }
    
         public DelinquentAccountsController(ICommandProvider commandProvider)
         {
             CommandProvider = commandProvider;
         }
    
         public ActionResult Index(decimal amount)
         {
             var query = CommandProvider.Create<IDelinquentAccountsQuery>();
             query.AmountGreaterThan(amount);
             return View(query.Execute());
    
         }
    }
