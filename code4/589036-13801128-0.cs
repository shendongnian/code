        PdfPTable aTable                = new PdfPTable(6);
        aTable.HorizontalAlignment      = Element.ALIGN_LEFT;
        aTable.WidthPercentage          = 100;
        doc.Add(aTable);
        PdfPTable tp                    = new PdfPTable(3);
        tp.HorizontalAlignment          = Element.ALIGN_LEFT;
        tp.WidthPercentage              = 60;
        tp.SetWidths(new []{60f, 20f, 20f});
