    public partial class BasePage : System.Web.UI.MasterPage
    { 
       private string[] _RequiredRoles = null;
       public string[] RequiredRoles
       {
         get { return _RequiredRoles; }
         set { _RequiredRoles = value; }
       }
     }
