    //ASPX page
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //accessing the SelectedIndex
          int dl= ((DropDownList)this.userControlName.FindControl("DropDownList1")).SelectedIndex;
        }
    }
