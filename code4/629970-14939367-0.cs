    public void ReturnPDF(byte[] contents, string attachmentFilename)
            {
                var response = HttpContext.Current.Response;
                try
                {
                    if (!string.IsNullOrEmpty(attachmentFilename))
                    {
                        response.ContentType = "application/pdf";
                        response.AddHeader("Content-Disposition", "attachment; filename=" + attachmentFilename);
                    }
    
                    response.ContentType = "application/pdf";
                    response.BinaryWrite(contents);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    response.End();
                    response.Flush();
                    response.Clear();
                }
    
    
            }
