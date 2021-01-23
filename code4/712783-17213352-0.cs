    public partial class Page : System.Web.UI.Page
    {
       private string[] companiesArray = {"Google","BBC","CNN","SportsDirect","Microsoft"};
       public void Page_Load(object sender, EventArgs e)
       {
          //companiesArray  is visible here
       }
    
       public void SomeOtherMethod()
       {
          //companiesArray is visible here too
       }
    }
