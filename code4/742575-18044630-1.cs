    using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse())
    {
        using (System.IO.Stream responseStream = httpResponse.GetResponseStream())
        {
            // let the browser know how to open the PDF document, attachment or inline, and the file name
            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=UberwriterUSRReport.pdf"));
          CopyStream(responseStream, HttpContext.Current.Response.OutputStream);
        }
    }
