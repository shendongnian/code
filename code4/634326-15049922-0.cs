    context.Request["Yourparameter"]
  
    public class RecieveMail : IHttpHandler
    {
        private string _emailAdressTo;
        private string _imageUrl;
        private EmailFactory _emailFactory;
    
        public void ProcessRequest(HttpContext context)
        {
            ImageFactory factory = new ImageFactory(context);
            try
            {
                _imageUrl = factory.SaveImage("uploaded");
    
                if (string.IsNullOrEmpty(context.Request["from"]) || string.IsNullOrEmpty(context.Request["to"])) return;
    
                _emailFactory = new EmailFactory(_imageUrl);
                if (_emailFactory.SendMail(context.Request["from"], context.Request["to"]))
                    context.Response.Write(!factory.DeleteImage(_imageUrl) ? "Email sent" : "Image deleted");
            }
            catch (Exception ex)
            {
                context.Response.Write(" error converting " + ex.Message);
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }    
    }
