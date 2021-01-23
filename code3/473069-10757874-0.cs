            HttpResponse response = HttpContext.Current.Response;
            try
            {
                DataSet dataSet = new DataSet();
                DataTable table = new DataTable();
                dataSet.Tables.Add(table);
                response.Clear();
                response.Charset = "";
                response.ContentType = "application/vnd.ms-excel";
                response.AddHeader("Content-Disposition", "attachment;filename=\"ExcelFile.xls\"");
                using (StringWriter stringWriter = new StringWriter())
                using (HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter))
                {
                    DataGrid dataGrid = new DataGrid { DataSource = dataSet.Tables[0] };
                    dataGrid.DataBind();
                    dataGrid.RenderControl(htmlTextWriter);
                    response.Write(stringWriter.ToString());
                }
            }
            catch (ThreadAbortException ex)
            {
                //Log some trace info here
            }
            finally
            {
                response.End();
            }
