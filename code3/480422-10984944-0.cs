    page = document.AddPage();
    //page.Size = PdfSharp.PageSize.A4;
    XSize size = PageSizeConverter.ToSize(PdfSharp.PageSize.A4);
    if(page.Orientation == PageOrientation.Landscape)
    {
       page.Width  = size.Height;
       page.Height = size.Width;
    }
    else
    {
       page.Width  = size.Width;
       page.Height = size.Height;
    }
    // default unit in points 1 inch = 72 points
    page.TrimMargins.Top = 5;
    page.TrimMargins.Right = 5;
    page.TrimMargins.Bottom = 5;
    page.TrimMargins.Left = 5;
