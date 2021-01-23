    public class BasePage : Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect(ResolveClientUrl("~/Login.aspx"));
            }        
        }
    }
