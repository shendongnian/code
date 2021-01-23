    System.String filePath = "c:\\tempFile.pdf"
    System.IO.FileInfo fileInfo = new FileInfo(filePath);
    
    System.Web.HttpContext context = System.Web.HttpContext.Current;
    System.Web.HttpResponse response = context.Response;
    response.Clear();
    response.ClearHeaders();
    response.ClearContent();
    response.ContentType = "application/pdf";
    response.AppendHeader("content-type", "application/pdf");
    response.AppendHeader("content-length", fileInfo.Length.ToString());
    response.AppendHeader("content-disposition", String.Format("attachment; filename={0}.pdf", outputFileName));
    response.TransmitFile(filePath);
    response.Flush(); // this make stream and without it open chrome save dialog
    context.ApplicationInstance.CompleteRequest(); // send headers and c# server-side code still continue
    System.IO.File.Delete(filePath); // clean cache here if you need
