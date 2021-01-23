    protected void dwnLoad(object sender, EventArgs e)
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=kbNotification.xls");
                Response.Charset = "";
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWrite);
                GridView1.RenderControl(htmlWriter);
                Response.Write(stringWrite.ToString());
                Response.End();
            }
