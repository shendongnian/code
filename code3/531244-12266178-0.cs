     //Export the datagrid to Excel
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            
            Response.AddHeader("content-disposition", "attachment; filename=SearchResults.xls");
            Response.ClearContent();
            Response.ContentType = "application/vnd.ms-excel";
            this.gvRequests.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
