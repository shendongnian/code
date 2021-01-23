    using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse())
    {
        using (System.IO.Stream responseStream = httpResponse.GetResponseStream())
        {
            var filepath = @"C:\Users\David\Downloads\UberwriterUSRReport.pdf";
            HttpContext.Current.Response.ContentType = "application/pdf";
            // let the browser know how to open the PDF document, attachment or inline, and the file name
            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=UberwriterUSRReport.pdf"));
            using (var stream = new System.IO.FileStream(filepath, System.IO.FileMode.Create)) {
              CopyStream(responseStream, stream);
            }
        
            using (var readstream = new System.IO.FileStream(filepath, System.IO.FileMode.Read)) {
        	    CopyStream(readstream, HttpContext.Current.Response.OutputStream);
            }
        }
    }
