    Create class name SMTP.cs then
    
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Net;
    
    
    
    /// <summary>
    /// Summary description for SMTP
    /// </summary>
    public class SMTP
    {
        private SmtpClient smtp;
    
        private static string _smtpIp;
        public static string smtpIp
        {
            get
            {
                if (string.IsNullOrEmpty(_smtpIp))
                    _smtpIp = System.Configuration.ConfigurationManager.AppSettings["smtpIp"];
    
                return _smtpIp;
    
            }
        }
    
    
        public SMTP()
        {
            smtp = new SmtpClient(smtpIp);
         }
    
        public string Send(string From, string Alias, string To, string Subject, string Body, string Image)
        {
            try
            {
                MailMessage m = new MailMessage("\"" + Alias + "\" <" + From + ">", To);
                m.Subject = Subject;
                m.Priority = MailPriority.Normal;
    
                AlternateView av1 = AlternateView.CreateAlternateViewFromString(Body, System.Text.Encoding.UTF8, MediaTypeNames.Text.Html);
    
                if (!string.IsNullOrEmpty(Image))
                {
                    string path = HttpContext.Current.Server.MapPath(Image);
                    LinkedResource logo = new LinkedResource(path, MediaTypeNames.Image.Gif);
                    logo.ContentId = "Logo";
                    av1.LinkedResources.Add(logo);
                }
    
                m.AlternateViews.Add(av1);
                m.IsBodyHtml = true;
    
                smtp.Send(m);
            }
            catch (Exception e)
            {
                return e.Message;
            }
    
            return "sucsess";
        }
    }
    
    then 
    
    on aspx page
    
    protected void lblSubmit_Click(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.ContentType = "text/plain";
            //Guid guid = Guid.NewGuid();
            string EmailMessage = "<html>" +
                                          "<head>" +
                                              "<meta http-equiv=Content-Type content=\"text/html; charset=utf-8\">" +
                                          "</head>" +
                                           "<body style=\"text-align:left;direction:ltr;font-family:Arial;\" >" +
                                           "<style>a{color:#0375b7;} a:hover, a:active {color: #FF7B0C;}</style>" +
                                                  "<img src=\"" width=\"190px\"  height= \"103px\"/><br/><br/>" +
                                                  "<p>Name:  " + nameID.Value + ",<br/><br/>" +
                                                    "<p>Email:  " + EmailID.Value + ",<br/><br/>" +
                                                      "<p>Comments:  " + commentsID.Text + "<br/><br/>" +
                                                 // "Welcome to the Test local updates service!<br/>Before we can begin sending you updates, we need you to verify your address by clicking on the link below.<br/>" +
                                                  //"<a href=\""></a><br/><br/>" +
    
                                                  //"We look forward to keeping you informed of the latest and greatest events happening in your area.<br/>" +
                                                  //"If you have any questions, bug reports, ideas, or just want to talk, please contact us at <br/><br/>" +
                                                  //"Enjoy! <br/>" + commentsID.Text + "<br/>" +
    
                                                   //"Test<br/><a href=\"">www.Test.com</a></p>" +
                                          "</body>" +
                                      "</html>";
    
            lblThank.Text = "Thank you for contact us.";
           // string Body = commentsID.Text;
            SMTP smtp = new SMTP();
            string FromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmail"];
            string mailReturn = smtp.Send(EmailID.Value, "", FromEmail, "Contact Us Email", EmailMessage, string.Empty);
            //HttpContext.Current.Response.Write("true");
            nameID.Value = "";
            EmailID.Value = "";
            commentsID.Text = "";
        }
