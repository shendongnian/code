    public class HomeController : AsyncController
    {
      public void SendMessageAsync()
      {
        var client = new SmtpClientWrapper();
        client.SendCompleted += (sender, args) => 
          AsyncManager.OutstandingOperations.Decrement();
        AsyncManager.OutstandingOperations.Increment();
        new UserMailer().Welcome().SendAsync("", client);
      }
      public ActionResult SendMessageCompleted()
      {
        return View();
      }
    }
