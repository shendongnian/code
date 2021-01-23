    public class Solution.Web.UI.Page : System.Web.UI.Page
    {
        public string CurrentMode 
        { 
            get { return String.Compare(Session["CurrentMod"].ToString(), "1") == 0) ? "module-1.xml" : "module-2.xml"; }
        }
    }
