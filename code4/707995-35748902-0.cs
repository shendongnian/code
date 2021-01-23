      BaseFont f_cn;
      string  poath = Server.MapPath("~/fonts/CALIBRI.TTF");
     f_cn = BaseFont.CreateFont(poath, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
    using (System.IO.FileStream fs = new FileStream(Server.MapPath("~/TempPdf") + "\\" + "download.pdf", FileMode.Create))
                {
     Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);                
                    Paragraph p = new Paragraph();
                    // Add meta information to the document
                    document.AddAuthor("Mikael Blomquist");
                    document.AddCreator("Sample application using iTestSharp");
                    document.AddKeywords("PDF tutorial education");
                    document.AddSubject("Document subject - Describing the steps creating a PDF document");
                    document.AddTitle("The document title - Amplified Resource Group");
                    // Open the document to enable you to write to the document
                    document.Open();
                    // Makes it possible to add text to a specific place in the document using 
                    // a X & Y placement syntax.
                    PdfContentByte cb = writer.DirectContent;
                    cb.SetFontAndSize(f_cb, 16);
                    // First we must activate writing
                    cb.BeginText();
                    // Add an image to a fixed position from disk
                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(Server.MapPath("~/images/arg.png"));
                    png.SetAbsolutePosition(200, 738);
                    cb.AddImage(png);
                    writeText(cb, "Header", 30, 718, f_cb, 14);
    }
     private void writeText(PdfContentByte cb, string Text, int X, int Y, BaseFont font, int Size)
        {
            cb.SetFontAndSize(font, Size);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Text, X, Y, 0);
      }
