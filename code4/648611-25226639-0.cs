    protected void convertToPdfButton_Click(object sender, EventArgs e)
    {
        // Create a HTML to PDF converter object with default settings
        HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();
        
        // Set the PDF file to be inserted before conversion result
        string pdfFileBefore = Server.MapPath("~/DemoAppFiles/Input/PDF_Files/Merge_Before_Conversion.pdf");
        htmlToPdfConverter.PdfDocumentOptions.AddStartDocument(pdfFileBefore, addHeaderFooterInInsertedPdfCheckBox.Checked,
                            showHeaderInFirstPageCheckBox.Checked, showFooterInFirstPageCheckBox.Checked);
    
        // Set the PDF file to be added after conversion result
        string pdfFileAfter = Server.MapPath("~/DemoAppFiles/Input/PDF_Files/Merge_After_Conversion.pdf");
        htmlToPdfConverter.PdfDocumentOptions.AddEndDocument(pdfFileAfter, addHeaderFooterInAppendedPdfCheckBox.Checked, true, true);
    
        // Enable header in the generated PDF document
        htmlToPdfConverter.PdfDocumentOptions.ShowHeader = true;
    
        // Draw header elements
        if (htmlToPdfConverter.PdfDocumentOptions.ShowHeader)
            DrawHeader(htmlToPdfConverter, true);
    
        // Enable footer in the generated PDF document
        htmlToPdfConverter.PdfDocumentOptions.ShowFooter = true;
    
        // Draw footer elements
        if (htmlToPdfConverter.PdfDocumentOptions.ShowFooter)
            DrawFooter(htmlToPdfConverter, true, true);
    
        string url = urlTextBox.Text;
    
        // Convert the HTML page to a PDF document and add the external PDF documents
        byte[] outPdfBuffer = htmlToPdfConverter.ConvertUrl(url);
    
        // Send the PDF as response to browser
    
        // Set response content type
        Response.AddHeader("Content-Type", "application/pdf");
    
        // Instruct the browser to open the PDF file as an attachment or inline
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Header_Footer_in_External_PDF.pdf; size={0}", outPdfBuffer.Length.ToString()));
    
        // Write the PDF document buffer to HTTP response
        Response.BinaryWrite(outPdfBuffer);
    
        // End the HTTP response and stop the current page processing
        Response.End();
    }
    
    /// <summary>
    /// Draw the header elements
    /// </summary>
    /// <param name="htmlToPdfConverter">The HTML to PDF Converter object</param>
    /// <param name="drawHeaderLine">A flag indicating if a line should be drawn at the bottom of the header</param>
    private void DrawHeader(HtmlToPdfConverter htmlToPdfConverter, bool drawHeaderLine)
    {
        string headerHtmlUrl = Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Header_HTML.html");
    
        // Set the header height in points
        htmlToPdfConverter.PdfHeaderOptions.HeaderHeight = 60;
    
        // Set header background color
        htmlToPdfConverter.PdfHeaderOptions.HeaderBackColor = Color.White;
    
        // Create a HTML element to be added in header
        HtmlToPdfElement headerHtml = new HtmlToPdfElement(headerHtmlUrl);
    
        // Set the HTML element to fit the container height
        headerHtml.FitHeight = true;
    
        // Add HTML element to header
        htmlToPdfConverter.PdfHeaderOptions.AddElement(headerHtml);
    
        if (drawHeaderLine)
        {
            // Calculate the header width based on PDF page size and margins
            float headerWidth = htmlToPdfConverter.PdfDocumentOptions.PdfPageSize.Width -
                        htmlToPdfConverter.PdfDocumentOptions.LeftMargin - htmlToPdfConverter.PdfDocumentOptions.RightMargin;
    
            // Calculate header height
            float headerHeight = htmlToPdfConverter.PdfHeaderOptions.HeaderHeight;
    
            // Create a line element for the bottom of the header
            LineElement headerLine = new LineElement(0, headerHeight - 1, headerWidth, headerHeight - 1);
    
            // Set line color
            headerLine.ForeColor = Color.Gray;
    
            // Add line element to the bottom of the header
            htmlToPdfConverter.PdfHeaderOptions.AddElement(headerLine);
        }
    }
    
    /// <summary>
    /// Draw the footer elements
    /// </summary>
    /// <param name="htmlToPdfConverter">The HTML to PDF Converter object</param>
    /// <param name="addPageNumbers">A flag indicating if the page numbering is present in footer</param>
    /// <param name="drawFooterLine">A flag indicating if a line should be drawn at the top of the footer</param>
    private void DrawFooter(HtmlToPdfConverter htmlToPdfConverter, bool addPageNumbers, bool drawFooterLine)
    {
        string footerHtmlUrl = Server.MapPath("~/DemoAppFiles/Input/HTML_Files/Footer_HTML.html");
    
        // Set the footer height in points
        htmlToPdfConverter.PdfFooterOptions.FooterHeight = 60;
    
        // Set footer background color
        htmlToPdfConverter.PdfFooterOptions.FooterBackColor = Color.WhiteSmoke;
    
        // Create a HTML element to be added in footer
        HtmlToPdfElement footerHtml = new HtmlToPdfElement(footerHtmlUrl);
    
        // Set the HTML element to fit the container height
        footerHtml.FitHeight = true;
    
        // Add HTML element to footer
        htmlToPdfConverter.PdfFooterOptions.AddElement(footerHtml);
    
        // Add page numbering
        if (addPageNumbers)
        {
            // Create a text element with page numbering place holders &p; and & P;
            TextElement footerText = new TextElement(0, 30, "Page &p; of &P;  ",
                new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));
    
            // Align the text at the right of the footer
            footerText.TextAlign = HorizontalTextAlign.Right;
    
            // Set page numbering text color
            footerText.ForeColor = Color.Navy;
    
            // Embed the text element font in PDF
            footerText.EmbedSysFont = true;
    
            // Add the text element to footer
            htmlToPdfConverter.PdfFooterOptions.AddElement(footerText);
        }
    
        if (drawFooterLine)
        {
            // Calculate the footer width based on PDF page size and margins
            float footerWidth = htmlToPdfConverter.PdfDocumentOptions.PdfPageSize.Width -
                        htmlToPdfConverter.PdfDocumentOptions.LeftMargin - htmlToPdfConverter.PdfDocumentOptions.RightMargin;
    
            // Create a line element for the top of the footer
            LineElement footerLine = new LineElement(0, 0, footerWidth, 0);
    
            // Set line color
            footerLine.ForeColor = Color.Gray;
    
            // Add line element to the bottom of the footer
            htmlToPdfConverter.PdfFooterOptions.AddElement(footerLine);
        }
    }
