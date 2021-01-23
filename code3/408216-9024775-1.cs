    public partial class somePage : BasePage  
    {
         protected  override void Page_Load(object sender, EventArgs e)
         {
             base.Page_Load(sender, e); //This line will execute page load from BasePage class
             //The rest of code you want to execute on this page load
         }
    }
