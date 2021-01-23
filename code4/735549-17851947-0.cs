    byte[] yourByteData = .. assign your pdf data here ....
    Response.ClearHeaders();
    Response.Clear();
    Response.AddHeader("Content-Type","application/pdf");
    Response.AddHeader("Content-Length",yourByteData.Length.ToString());
    Response.AddHeader("Content-Disposition","inline; filename=sample.pdf");
    Response.BinaryWrite(yourByteData);
    Response.Flush();
    Response.End();
