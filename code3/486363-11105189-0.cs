    public class BasePage : WebPage {
      protected void Page_PreInit(object sender, EventArgs e){
        //do stuff here
      }
    }
    
    public class MyPage : BasePage {
      protected void Page_PreInit(object sender, EventArgs e){
        //overwrites base class functionality
        //Pretty sure you can:
        base.Page_PreInit(sender,e);
      }
    }
