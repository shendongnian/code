        {
            Response.ClearContent();
            Response.Buffer = true;
            string fileName="filname.xlsm";Response.AddHeader("content-disposition",  string.Format("attachment;filename={0}",fileName));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            ListView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
       
