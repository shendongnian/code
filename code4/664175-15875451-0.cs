    HttpResponse response = HttpContext.Current.Response;
    
                // First let's clean up the response.object.
                response.Clear();
                response.Charset = "";
    
                // Set the response mime type for Excel.
                response.ContentType = "application/vnd.ms-excel";
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
    
                // Create a string writer.
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        // Instantiate a datagrid
                        DataGrid dg = new DataGrid();
                        dg.DataSource = ds.Tables[0];
                        dg.DataBind();
                        dg.RenderControl(htw);
                        response.Write(sw.ToString());
                        response.End();
                    }
                }
