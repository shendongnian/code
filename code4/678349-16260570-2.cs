    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ctrlPageControl.mChildControl.Checked = true;
            this.ctrlPageControl.mChildControl.Text = "YoooHooo!";
        }
    }
