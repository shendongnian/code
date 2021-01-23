    var task1 = Task.Factory.StartNew(() =>
        {
        System.Web.HttpContext.Current = ControllerContext.HttpContext.ApplicationInstance.Context;
        var mail = new UserMailer();
        var msg = mail.Welcome("My Name", "myemail@gmail.com");
        msg.SendAsync();
        });
    task1.Wait();
