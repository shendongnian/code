    public partial class _Default : System.Web.UI.Page
    {
        protected void btn_clicked(object sender, EventArgs e)
        {
            int clickCount;
            try
            {
            	clickCount = int.Parse(Session["ClickCount"]);
            	clickCount++;
            }
            catch
            {
            	clickCount = 1;	
            }
    
            Session["ClickCount"] = clickCount;
    
            if (clickCount == 1)
            {
                (sender as Button).Text = "go to landing page";
            }
            else
            {
                Response.Redirect("LandingPage.aspx");
            }
        }
    }
