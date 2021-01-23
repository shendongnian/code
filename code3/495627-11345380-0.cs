    Response.ClearHeaders();
    Response.Clear();
    Response.AddHeader("Content-Type","application/pdf");
    Resopnse.AddHeader("Content-Length",byteArray.Length.ToString());
    Response.AddHeader("Content-Disposition","inline; filename=sample.pdf");
    Response.BinaryWrite(byteArray);
    Response.Flush();
    Response.End();
