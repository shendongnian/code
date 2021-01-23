    // Add headers for a csv file or whatever
    Response.ContentType = "text/csv"
    Response.AddHeader("Content-Disposition", "attachment;filename=report.csv")
    Response.AddHeader("Pragma", "no-cache")
    Response.AddHeader("Cache-Control", "no-cache")
    
    // Write the data as binary from a unicode string
    Dim buffer As Byte()
    buffer = System.Text.Encoding.Unicode.GetBytes(csv)
    Response.BinaryWrite(buffer)
    
    // Sends the response buffer
    Response.Flush()
    
    // Prevents any other content from being sent to the browser
    Response.SuppressContent = True
    
    // Directs the thread to finish, bypassing additional processing
    HttpContext.Current.ApplicationInstance.CompleteRequest()
