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
                GridView1.AllowPaging = false;
                GridView1.DataBind();
                GridView1.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
           
            public override void VerifyRenderingInServerForm(Control control)
            {
                /* Verifies that the control is rendered */
            }
