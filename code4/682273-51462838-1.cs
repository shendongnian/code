    public class PageUtility
    {
        public static void MessageBox(System.Web.UI.Page page,string strMsg)
        {
            //+ character added after strMsg "')"
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + strMsg + "')", true);
        }
    }
