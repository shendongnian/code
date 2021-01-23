    public partial class SamplePage : System.Web.UI.Page
    {
        int UserID;
      protected void Page_Load(object sender, EventArgs e)
      {
      }
     protected void btnSearchUser_Click(object sender, EventArgs e)
     {
        UserID=5;
        ViewState["UserID"] = UserID;
     }
     protected void btnSubmit_Click(object sender, EventArgs e)
     {
        if(ViewState["UserID"]!=null)
        Response.Write(ViewState["UserID"].ToString());
     }
    }
