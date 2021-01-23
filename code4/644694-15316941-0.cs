    public partial class ContactUs : System.Web.UI.Page
    {
       [WebMethod]
       public static void SendForm(string name, string email, string message)
       {
           if (string.IsNullOrEmpty(name))
           {
               throw new Exception("You must supply a name.");
           }
    
           if (string.IsNullOrEmpty(email))
           {
               throw new Exception("You must supply an email address.");
           }
    
           if (string.IsNullOrEmpty(message))
           {
               throw new Exception("Please provide a message to send.");
           }
    
           //call your web service here, or do whatever you wanted to do
       }
    }
