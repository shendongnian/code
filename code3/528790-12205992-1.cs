    var task1 = Task.Factory.StartNew(
       state =>
          {
            var context = (HttpContext) state;
            var mail = new UserMailer();
            var msg = mail.Welcome("My Name", "myemail@gmail.com");
            msg.SendAsync();
          },
       HttpContext.Current);
