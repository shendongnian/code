    using iTextSharp.text;
    // Set up the fonts to be used on the pages 
    private Font _largeFont = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD, BaseColor.BLACK); 
    private Font _standardFont = new Font(Font.FontFamily.HELVETICA, 14, Font.NORMAL, BaseColor.BLACK); 
    private Font _smallFont = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.BLACK);
    public void Build() 
    { 
       iTextSharp.text.Document doc = null;
       try 
       { 
           // Initialize the PDF document 
           doc = new Document(); 
           iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, 
               new System.IO.FileStream(System.IO.Directory.GetCurrentDirectory() + "\\ScienceReport.pdf", 
                   System.IO.FileMode.Create));
           // Set margins and page size for the document 
           doc.SetMargins(50, 50, 50, 50); 
           // There are a huge number of possible page sizes, including such sizes as 
           // EXECUTIVE, LEGAL, LETTER_LANDSCAPE, and NOTE 
           doc.SetPageSize(new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.LETTER.Width, 
               iTextSharp.text.PageSize.LETTER.Height));
           // Add metadata to the document.  This information is visible when viewing the 
           // document properities within Adobe Reader. 
           doc.AddTitle("My Science Report"); 
           doc.AddCreator("M. Lichtenberg"); 
           doc.AddKeywords("paper airplanes");
           // Add Xmp metadata to the document. 
           this.CreateXmpMetadata(writer);
           // Open the document for writing content 
           doc.Open();
           // Add pages to the document 
           this.AddPageWithBasicFormatting(doc); 
           this.AddPageWithInternalLinks(doc); 
           this.AddPageWithBulletList(doc); 
           this.AddPageWithExternalLinks(doc); 
           this.AddPageWithImage(doc, System.IO.Directory.GetCurrentDirectory() + "\\FinalGraph.jpg");
           // Add page labels to the document 
           iTextSharp.text.pdf.PdfPageLabels pdfPageLabels = new iTextSharp.text.pdf.PdfPageLabels(); 
           pdfPageLabels.AddPageLabel(1, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "Basic Formatting"); 
           pdfPageLabels.AddPageLabel(2, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "Internal Links"); 
           pdfPageLabels.AddPageLabel(3, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "Bullet List"); 
           pdfPageLabels.AddPageLabel(4, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "External Links"); 
           pdfPageLabels.AddPageLabel(5, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "Image"); 
           writer.PageLabels = pdfPageLabels; 
       } 
       catch (iTextSharp.text.DocumentException dex) 
       { 
           // Handle iTextSharp errors 
       } 
       finally 
       { 
           // Clean up 
           doc.Close(); 
           doc = null; 
       } 
    }
