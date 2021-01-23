    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public partial class _Default : System.Web.UI.Page
    {
        protected void opnTest1PDF(Object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(
                this.GetType(),
                "myFileOpenScript",
                "<script>window.open('test1.pdf');</script>");
        }
        protected void opnTest2PDF(Object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(
                this.GetType(),
                "myFileOpenScript",
                "<script>window.open('test2.pdf');</script>");
        }
    }
