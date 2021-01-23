    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    
    public partial class WebUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                this.gridView.DataSource = this.SqlDataSource1;
                this.gridView.DataBind();
         
        }
        private void excel_Export()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
              "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.gridView.AllowPaging=false;
            this.gridView.DataBind();
            this.gridView.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            excel_Export();
        }
    }
