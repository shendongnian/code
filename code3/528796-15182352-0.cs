    using Mvc.Mailer; 
    using System.Threading.Tasks;
    public static void SendEmailAsync(this MvcMailMessage msg, HttpContext currContext)
    {
          //make this process a little cleaner
          Task.Factory.StartNew(() =>
          {
               System.Web.HttpContext.Current = currContext;
               msg.SendAsync();
           });
    }
