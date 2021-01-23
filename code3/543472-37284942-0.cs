        public string Download(string file)        
    {
        
        string filePath = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FileManagementPath"]);
        
                        
                    string actualFilePath = System.IO.Path.Combine(filePath, file);
                    HttpContext.Response.ContentType = "APPLICATION/OCTET-STREAM";
                    string filename = Path.GetFileName(actualFilePath);
                    String Header = "Attachment; Filename=" + filename;
                    HttpContext.Response.AppendHeader("Content-Disposition", Header);           
                    HttpContext.Response.WriteFile(actualFilePath);
                    HttpContext.Response.End();
                    return "";
                }
