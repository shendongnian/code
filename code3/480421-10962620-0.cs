    page = document.AddPage();
    //page.Size = PdfSharp.PageSize.A4;
    XSize size = PageSizeConverter.ToSize(PdfSharp.PageSize.A4);
    page.MediaBox = new PdfRectangle(new XPoint(0, 0), new XPoint(size.Height, size.Width)); // Magic: swap width and height
    //page.Orientation = PageOrientation.Landscape;
