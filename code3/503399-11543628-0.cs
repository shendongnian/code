    public class SiteController : AsyncController
    {
        public void SynchronizeAsync()
        {
            AsyncManager.OutstandingOperations.Increment();
            
            SiteModel.GetHeadlinesCompleted += (sender, e) =>
            {
                AsyncManager.OutstandingOperations.Decrement();
            };
            SiteModel.synchronizeDBWithIISAsync();
        }
        public ActionResult SynchronizeCompleted()
        {
            return Content("Cool.");
        }
    }
