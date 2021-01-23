    public partial class Counter : System.Web.UI.Page
    {
        int sessionCount = 0;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CountCounter"] == null)
                sessionCount = 0;
            else
                sessionCount = Convert.ToInt32(Session["CountCounter"]);
            sessionCount++;
           
            // **NEW** Save the new count value
            Session["CountCounter"] = sessionCount;
    
            lblAboutCount.Text = Session["CountAbout"];
            lblCommentCount.Text = Session["CountComment"];
            lblCompletedCount.Text = Session["CountCompleted"];
            lblContactCount.Text = Session["CountContact"];
            lblCounterCount.Text = sessionCounter;
            lblCurrentCount.Text = Session["CountCurrent"];
            lblMainCount.Text = Session["CountMain"];
        }
