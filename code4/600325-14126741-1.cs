    public class BasePage : System.Web.UI.Page
    {
    
      public user secure_username
      {get;set;}
      
      protected void Page_Load(object sender, EventArgs e)
      {
        //add your checks that repeat on each page
      }
    }
