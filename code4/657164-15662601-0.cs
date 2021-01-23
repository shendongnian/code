    public class MyPage : System.Web.UI.Page
     protected void Page_Load(object sender, EventArgs e)
     {
       if (Session["yoursession"] != "true")
       {
         //code
       }
     }
    
    
    
    public class yourCustomPage1 : MyPage
    {   
     protected void Page_Load(object sender, EventArgs e)
     {
       //you don't have to check or call any method..
     }
    }
    public class yourCustomPage2 : MyPage
    {   
     protected void Page_Load(object sender, EventArgs e)
     {
       //you don't have to check or call any method..
     }
    }
