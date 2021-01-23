            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=YourFilePath");
            Response.ContentType = "application/pdf";
            var sw = new StringWriter();
            var htw = new HtmlTextWriter(sw);
            //// Create a form to contain the grid
            var frm = new HtmlForm();
            frm.Attributes["runat"] = "server";
            frm.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
