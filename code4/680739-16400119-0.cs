    public override void OnResultExecuted(ResultExecutedContext context)
    {
        // Get the HTML from the request.
        string html = sb.ToString();
        // PdfController is where the PDF generation logic lives; instantiate it.
        var pdfController = new PdfController();
        // Generate a user-friendly filename for the PDF.
        string filename = pdfController.GetPdfFilename(html);
        // Generate the PDF and convert it to a byte array.
        FileInfo pdfInfo = pdfController.HtmlToPdf(html);
        // Render the PDF as a byte array; if it can't be rendered, use an empty byte array instead.
        byte[] pdfBytes = (pdfInfo.Exists && pdfInfo.Length > 0 ? File.ReadAllBytes(pdfInfo.FullName) : new byte[]{});
        // If the PDF or a user-friendly filename could not be generated, return the raw HTML instead.    
        if (pdfBytes.Length == 0 || String.IsNullOrWhitespace(filename))
        {
            output.Write(html);
            return;
        }
        // If a PDF was generated, stream it to the browser for downloading.
        context.HttpContext.Response.Clear();
        context.HttpContext.Response.AddHeader("Content-Type", "application/pdf");
        context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + "\";");
        context.HttpContext.Response.AddHeader("Content-Length", pdfBytes.Length.ToString());
        output.WriteBytes(pdfBytes, 0, pdfBytes.Length);
        context.HttpContext.Response.Flush();
        context.HttpContext.Response.Close();
        context.HttpContext.Response.End();
    }
