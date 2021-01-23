    PdfContentByte over = writer.DirectContent;
    over.SaveState();
    over.BeginText();
    over.SetFontAndSize(BaseFont.CreateFont(), 9);        
    over.ShowTextAligned(Element.ALIGN_LEFT, "Your Text", x, y, 0);
    over.SetLineWidth(0.3f);        
    over.EndText();
    over.RestoreState();
