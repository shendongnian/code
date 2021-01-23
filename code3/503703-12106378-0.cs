    string templateFileName = Server.MapPath("~/ReportingTemplate/test.xlsx");
                    System.IO.FileInfo templateFile = new System.IO.FileInfo(templateFileName);
    
                    String message = ExcelPackagePlusLibrary.EPPlus.ExportToExcel(templateFile, dt, false, exportFileName, Response, "Data", "Summary", "Please type the client name here");
                    if (String.IsNullOrEmpty(message) == false)
                    {
                        /* Exception occur. */
                    }
                    dt.Clear();
    ///////////////////////////////////////////////////////////////////////////////////////
    
        /// <summary>
                /// ExportToExcel is a method used for Export To Excel with template file.
                ///
                /// </summary>
                /// <param name="templateFile">The fully qualified name of the new file, or the relative file name. Do not end the path with the directory separator character.</param>
                /// <param name="dt">Datatable for export.</param>
                /// <param name="printHeaders">Datatable's header used or not, when Export it. </param>
                /// <param name="exportFileName">provide fileName only not path. </param>
                /// <param name="Response">System.Web.HttpResponse. </param>
                /// <param name="sheetNames">arg[0] means provide sheet name where you want to load data. \n (Optional Parameter) arg[1] means provide sheet name where you want to edit. (Optional Parameter) arg[2] means if your intention is to Edit sheet so provide searchText.</param>
                /// 
                public static string ExportToExcel(FileInfo templateFile, DataTable dt, bool printHeaders, string exportFileName, System.Web.HttpResponse Response, params String[] sheetNames)
                {
                    try
                    {
                        using (ExcelPackage p = new ExcelPackage(templateFile, false))
                        {
                            EPPlus.AddSheetWithTemplate(p, dt, sheetNames[0], printHeaders);
        
        
                            String[] clientName = exportFileName.Split(new char[] { '_' }, 2);
        
                            if (sheetNames.Count() > 2)
                            {
                                ExcelPackagePlusLibrary.EPPlus.EditSheet(p, sheetNames[1], sheetNames[2], clientName[0] ?? exportFileName);
                            }
        
                            Byte[] fileBytes = p.GetAsByteArray(); //Read the Excel file in a byte array
        
                            //Clear the response
                            Response.ClearHeaders();
                            Response.ClearContent();
                            Response.Clear();
        
                            //Response.Cookies.Clear();
        
        
                            //Add the header & other information
                            //Response.Cache.SetCacheability(System.Web.HttpCacheability.Private);
                            //Response.CacheControl = "private";
                            //Response.Charset = System.Text.UTF8Encoding.UTF8.WebName;
                            //Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
                            //Response.AppendHeader("Content-Length", fileBytes.Length.ToString());
                            //Response.AppendHeader("Pragma", "cache");
                            //Response.AppendHeader("Expires", "60");
                            Response.AddHeader("Content-Disposition",
                            "attachment; " +
                            "filename=" + exportFileName + "; " +
                            "size=" + fileBytes.Length.ToString() + "; " +
                            "creation-date=" + DateTime.Now.ToString("R").Replace(",", "") + "; " +
                            "modification-date=" + DateTime.Now.ToString("R").Replace(",", "") + "; " +
                            "read-date=" + DateTime.Now.ToString("R").Replace(",", ""));
        
                            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.ContentType = "application/x-msexcel";
        
                            //Write it back to the client
                            Response.BinaryWrite(fileBytes);
                            Response.Flush();
                            Response.Close();
        
                            /* Download to Client Side. */
                            //DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Testing/Downloaded/" + DateTime.Now.ToString("MM-dd-yyyy")));
                            //if (!dir.Exists)
                            //{
                            //    dir.Create();
                            //}
                            //File.WriteAllBytes(dir.FullName + "\\" + fileName, fileBytes);
        
                            return String.Empty;
                        }
                    }
                    catch (Exception ex)
                    {
                        _ErrorMessage = ex.Message.ToString();
                        return _ErrorMessage;
                    }
                }
