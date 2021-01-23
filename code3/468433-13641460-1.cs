    post.From = new MailAddress(From);
    post.To.Add(To);
    post.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    post.Subject = Subject;
    post.Body = Body;
 
    var htmlView = AlternateView.CreateAlternateViewFromString(post.Body, null, "text/html");
    post.AlternateViews.Add(htmlView);
 
    if (attachments != null && attachments.Count > 0)
    {
        foreach (var at in attachments)
        {
            post.Attachments.Add(at1);
        }
    }
 
    post.IsBodyHtml = true;
 
    //if you have relay privilege you can use only host data; 
    //var host = "Your SMTP Server IP Adress";
    //var postman = new SmtpClient(host);
 
    //you dont have relay privilege you must be use Network Credential
    var postman = new SmtpClient("Host Server Name", Port);
    NetworkCredential cred = new NetworkCredential(mail adress, password);
    postman.UseDefaultCredentials = false;
    postman.Credentials = cred;
    postman.Send(post);
    post.Dispose();
    return true;
