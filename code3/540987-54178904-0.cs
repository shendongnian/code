    public class BasePage : System.Web.UI.Page {
            public void ShowNotif(string sMessage) {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(), "alert('" + sMessage.Replace("'", "\'") + "'); ", true);
            }
    }
