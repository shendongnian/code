    using Mvc.Mailer;
    ...
    public ActionResult SendWelcomeMessage()
    {
        Task.Factory.StartNew(() => UserMailer.Welcome().SendAsync());
        return RedirectToAction("Index");
    }
