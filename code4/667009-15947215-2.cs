    namespace WebApplication3.asp_x
    {
       public partial class _Default : System.Web.UI.Page
       {
          protected void Page_Load(object sender, EventArgs e)
          {
            WebApplication3.asc_x.WebUserControl1 ob=new WebApplication3.asc_x.WebUserControl1();
            LinkButton lb = ob.lbTest;
          }
       }
    }
