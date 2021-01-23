      public void GenerateXLS(string pFileName, DataTable pdtSource)
            {
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.Charset = "";
                // set the response mime type for excel 
        
                if ((pFileName + "-").ToLower().Contains(".xlsx-"))
                {
                    response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                }
                else
                {
                    response.ContentType = "application/vnd.ms-excel";
                }
        
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + pFileName + "\"");
        
                // create a string writer 
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        // instantiate a datagrid 
                        GridView gvExport = new GridView();
                        gvExport.DataSource = pdtSource;
                        gvExport.DataBind();
                        //(start): require for date format issue
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
        
                        foreach (GridViewRow r in gvExport.Rows)
                        {
                            if (r.RowType == DataControlRowType.DataRow)
                            {
                                for (int columnIndex = 0; columnIndex < r.Cells.Count; columnIndex++)
                                {
                                    r.Cells[columnIndex].Attributes.Add("class", "text");
                                }
                            }
                        }
                        //(end): require for date format issue
        
                        gvExport.RenderControl(htw);
                        //(start): require for date format issue
                        System.Text.StringBuilder style = new System.Text.StringBuilder();
                        style.Append("<style>");
                        style.Append("." + "text" + " { mso-number-format:" + "\\@;" + " }");
                        style.Append("</style>");
                        response.Clear();
                        Response.Buffer = true;
                        //response.Charset = "";
                        //response.Write(sw.ToString());
                        Response.Write(style.ToString());
                        Response.Output.Write(sw.ToString());
                        Response.Flush();
                        //(end): require for date format issue
                        try
                        {
                            response.End();
                        }
                        catch (Exception err)
                        {
        
                        }
                        //HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                }
            }
