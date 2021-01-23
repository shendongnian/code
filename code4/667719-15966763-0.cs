    namespace BookStore
    {
        public partial class index : BasePage
        {
             
        }
    }
    
    namespace Admin.BookStore
    {
        public partial class index : BasePage
        {
            void access()
            {
                base.command = "something text"; // This accesses the BasePage variable
            }
        }
    }
    namespace BookStore
    {
         public class BasePage : System.Web.UI.Page
         {
              // public static string command { get; set; } // Bad practice IMO
              public string command 
              {
                   get {
                       if(Session["command"] != null) return Session["command"].ToString();
                       return String.Empty;
                   }
                   set {
                       Session["command"] = value;
                   }
              }  
         }
    }
