     // send the PDF document as a response to the browser for download
     System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
    
     response.ContentType = "application/pdf";
     if (!displayOnBrowser)
     {  response.AddHeader("Content-Disposition", String.Format("attachment; filename=GettingStarted.pdf; size={0}", pdfBytes.Length.ToString())); 
     }
     else
     {  response.AddHeader("Content-Disposition", String.Format("inline; filename=GettingStarted.pdf; size={0}", pdfBytes.Length.ToString()));
     }
     response.BinaryWrite(pdfBytes);
     // Note: it is important to end the response, otherwise the ASP.NET
     // web page will render its content to PDF document stream
     response.End();
