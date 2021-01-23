        PdfPCell c;
        c = new PdfPCell(new Phrase(@"Sample text", font));
        c.HorizontalAlignment = Element.ALIGN_CENTER;
        c.VerticalAlignment = Element.ALIGN_MIDDLE;
        c.BackgroundColor = iTextSharp.text.Color.BLACK;
        table.AddCell(c);
