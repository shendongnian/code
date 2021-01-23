    using System;
    public partial class test : System.Web.UI.Page
    {
     public string clickedalbum = "";
    protected void Page_Load(object sender, EventArgs e)
    {
         clickedalbum = "attendance1.aspx?albumid=123";
         DataBind();
    }
    }
