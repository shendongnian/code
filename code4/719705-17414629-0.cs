    public class HomeController : AsyncController 
         {
             public void ExtensiveTaskActionAsync() 
             {
                 AsyncManager.OutstandingOperations.Increment();
                 Task.Factory.StartNew(() => DoLengthyOperation());
             }
          
             private void DoExtensiveTask()
            {
                Thread.Sleep(5000); // some task that could be extensive
                AsyncManager.Parameters["message"] = "hello world";
                AsyncManager.OutstandingOperations.Decrement();
            }
         
         
            public ActionResult ExtensiveTaskActionCompleted(string message) 
            {
                //task complete so, return the result
                return View();
            }
        }
