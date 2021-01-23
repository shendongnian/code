    using System;
    public partial class user : System.Web.UI.UserControl{
    public string test = "This is a test";
    protected void Page_Load(object sender, EventArgs e){
        this.DataBind();
    }
    }
