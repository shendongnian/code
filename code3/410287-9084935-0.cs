            //export button calls this
            private void ExportReport()
            {
                SetPublicVariables();
                System.Data.DataTable dt = GetDataSource(false); 
    
                string exportData = buildCSVExportString(dt);
    
                string filename = string.Format("{0} - {1}.csv",
                    (Master as MasterPages.Drilldown).Titlelbl.Text, CampaignTitle);
                if (filename.Length > 255) filename = filename.Substring(0, 255);
    
                ExportCSV(exportData, filename);
            }
    
    //build a string CSV
    public static string buildCSVExportString(DataTable exportDT)
            {
                StringBuilder exportData = new StringBuilder();
                // get headers.
                
                int iColCount = exportDT.Columns.Count;
                for (int i = 0; i < iColCount; i++)
                {
                   exportData.Append(exportDT.Columns[i].ToString());
                    if (i < iColCount - 1)
                    {
                        exportData.Append(",");
                    }
                }
                exportData.Append(System.Environment.NewLine);            
                
                // get rows.
                foreach (DataRow dr in exportDT.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
    						//If the variable is a string it potentially has charaters that can't be parsed properly.
    						//this fixes the comma issue(which adds aditional columns).  Replace and escape " with "".
    						if (dr[i] is string)		
    							exportData.Append(String.Format(@"""{0}""", ((string)dr[i]).Replace("\"", @"""""")));
    						else
    							exportData.Append(dr[i].ToString());
                        }
                        if (i < iColCount - 1)
                        {
                            exportData.Append(",");
                        }
                    }
                    exportData.Append(System.Environment.NewLine);
                }
                return exportData.ToString();
            }
    
    
    
    public void ExportCSV(string content, string filename)
    		{
    			filename = RemoveIllegalPathChars(filename);
    			HttpResponse Response = HttpContext.Current.Response;
    			string ext = System.IO.Path.GetExtension(filename);
    			Response.ClearHeaders();
    			Response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"", filename));
    			Response.ContentType = "text/csv; charset-UTF-8;";
    			Response.Clear();
    			Response.Write(content);
    			Response.End();
    		}
