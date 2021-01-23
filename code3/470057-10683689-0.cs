    public class BasePage : System.Web.UI.Page
    {
        protected Site1 Site1Master
        {
            get { return Master as Site1; }
        }
    }
