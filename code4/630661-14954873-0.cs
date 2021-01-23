    using System.Net.Mail;
    string messageHtml= @"<html><body> Your message text 
                      <img src=""cid:12345"" />
                      <img src=""cid:123456"" /></body></html>";
    AlternateView view= AlternateView.CreateAlternateViewFromString(messageHtml, null, MediaTypeNames.Text.Html);
    
    LinkedResource pic= new LinkedResource("pics.jpg", MediaTypeNames.Image.Jpeg);
    pic.ContentId = "12345";
    LinkedResource pic2= new LinkedResource("pic2.jpg", MediaTypeNames.Image.Jpeg);
    pic2.ContentId = "123456";
    view.LinkedResources.Add(pic);
    view.LinkedResources.Add(pic2);
    
    MailMessage mail = new MailMessage();
    mail.AlternateViews.Add(view);
    
    mail.send();
