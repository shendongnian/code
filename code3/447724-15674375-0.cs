    try
    
        {
            //your code
        }
    
    catch (Exception ex)
    
        {
            Response.Write(ex.Message);
        }
    
    finally
    
        {
            ReportDocument.Close();
            ReportDocument.Dispose();
        }
