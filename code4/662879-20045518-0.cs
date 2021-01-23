    string filename = String.Format("Results_{0}_{1}.xls", DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString());
            if (!string.IsNullOrEmpty(GRIDVIEWNAME.Page.Title))
                filename = GRIDVIEWNAME.Page.Title + ".xls";
            HttpContext.Current.Response.Clear();
           
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.Charset = "";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
           
            System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
            GRIDVIEWNAME.Parent.Controls.Add(form);
            form.Controls.Add(GRIDVIEWNAME);
            form.RenderControl(htmlWriter);
            HttpContext.Current.Response.Write("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            HttpContext.Current.Response.Write(stringWriter.ToString());
            HttpContext.Current.Response.End();
