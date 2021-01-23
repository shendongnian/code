    public class PageUtility
    {
        public static void MessageBox(System.Web.UI.Page page,string strMsg)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + strMsg "')", true);
        }
    }
