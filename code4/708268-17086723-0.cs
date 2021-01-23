    /// <summary>
    /// Convert the HTML code from the specified URL to a PDF document
        and send the document to the browser
    /// </summary>
    private void ConvertURLToPDF()
    {
        string urlToConvert = textBoxWebPageURL.Text.Trim();
        // Create the PDF converter. Optionally the HTML viewer width can
            be specified as parameter
        // The default HTML viewer width is 1024 pixels.
        PdfConverter pdfConverter = new PdfConverter();
        // set the license key - required
        pdfConverter.LicenseKey = "R8nYyNnI2MjRxtjI29nG2drG0dHR0Q==";
        // set the converter options - optional
        pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
        pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
        pdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
        // set if header and footer are shown in the PDF - optional - default
            is false 
        pdfConverter.PdfDocumentOptions.ShowHeader = cbAddHeader.Checked;
        pdfConverter.PdfDocumentOptions.ShowFooter = cbAddFooter.Checked;
        // set if the HTML content is resized if necessary to fit the PDF
            page width - default is true
        pdfConverter.PdfDocumentOptions.FitWidth = cbFitWidth.Checked;
        // set the embedded fonts option - optional - default is false
        pdfConverter.PdfDocumentOptions.EmbedFonts = cbEmbedFonts.Checked;
        // set the live HTTP links option - optional - default is true
        pdfConverter.PdfDocumentOptions.LiveUrlsEnabled = cbLiveLinks.Checked;
        // set if the JavaScript is enabled during conversion to a PDF - default
            is true
        pdfConverter.JavaScriptEnabled = cbClientScripts.Checked;
        // set if the images in PDF are compressed with JPEG to reduce the
            PDF document size - default is true
        pdfConverter.PdfDocumentOptions.JpegCompressionEnabled = cbJpegCompression.Checked;
        // enable auto-generated bookmarks for a specified list of HTML selectors
            (e.g. H1 and H2)
        if (cbBookmarks.Checked)
        {
            pdfConverter.PdfBookmarkOptions.HtmlElementSelectors = new string[] { "H1", "H2" };
        }
        // add HTML header
        if (cbAddHeader.Checked)
            AddHeader(pdfConverter);
        // add HTML footer
        if (cbAddFooter.Checked)
            AddFooter(pdfConverter);
        // Performs the conversion and get the pdf document bytes that can
        
        // be saved to a file or sent as a browser response
        byte[] pdfBytes = pdfConverter.GetPdfBytesFromUrl(urlToConvert);
        // send the PDF document as a response to the browser for download
        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.Clear();
        response.AddHeader("Content-Type", "application/pdf");
        if (radioAttachment.Checked)
            response.AddHeader("Content-Disposition", 
                    String.Format("attachment; filename=GettingStarted.pdf; size={0}", 
                    pdfBytes.Length.ToString()));
        else
            response.AddHeader("Content-Disposition", 
                    String.Format("inline; filename=GettingStarted.pdf; size={0}", 
                    pdfBytes.Length.ToString()));
        response.BinaryWrite(pdfBytes);
        // Note: it is important to end the response, otherwise the ASP.NET
        // web page will render its content to PDF document stream
        response.End();
    }
