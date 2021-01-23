    Response.Clear(); 
    Response.AddHeader("content-disposition", "attachment; filename=\"" + fileName + ".doc\""); 
    Response.ContentType = "application/msword"; 
    // This writes the document to the output stream.
    Report.SaveAs(response.OutputStream); 
    Response.End(); 
