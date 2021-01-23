    public class MyBaseController : Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            return new MyActionInvoker();
        }
    }
