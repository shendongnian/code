    [SessionState(SessionStateBehavior.Disabled)]
    public class HomeController : AsyncController
    {
        public ActionResult IndexSync()
        {
            Thread.Sleep(5000);
            return Content("completed", "text/plain"); 
        }
        public void IndexAsync()
        {
            AsyncManager.OutstandingOperations.Increment();
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                AsyncManager.OutstandingOperations.Decrement();
            });
        }
        public ActionResult IndexCompleted()
        {
            return Content("completed", "text/plain");
        }
    }
