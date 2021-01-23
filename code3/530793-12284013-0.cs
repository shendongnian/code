    public void ProcessRequest(HttpContext context)
    {
        // Makes sure the page does not get cached
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        // Retrieves the PDF
        byte[] PDFContent = BL.PDFGenerator.GetPDF(context.Request.QueryString["DocNumber"]);
        // Send it back to the client
        context.Response.ClearHeaders();
        context.Response.ContentType = "application/pdf";
        context.Response.BinaryWrite(PDFContent);
        context.Response.Flush();
        context.Response.End();
    }
