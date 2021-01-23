     public partial class MyCustomPage : System.Web.UI.Page
     {
        public override void VerifyRenderingInServerForm(Control control)
        {         
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var p = new MyCustomPage();
            FormAtt uc = (FormAtt)p.LoadControl("path/to/my/file.ascx");
            p.Controls.Add(uc);
        }
    }
