    // Create a new PDF document
    PdfDocument document = new PdfDocument();
    
    // Create an empty page with the default size/orientation
    PdfPage page = document.AddPage();
    page.Orientation = PageOrientation.Landscape;
    page.Width = XUnit.FromMillimeter(300);
    page.Height = XUnit.FromMillimeter(200);
    
    // Get an XGraphics object for drawing
    XGraphics gfx = XGraphics.FromPdfPage(page);
    
    // Add the first rectangle
    XUnit horizontalOffset = XUnit.FromMillimeter(5);
    XUnit verticalOffset = XUnit.FromMillimeter(5);
    XUnit columnWidth = XUnit.FromMillimeter(100);
    XUnit columnHeight = page.Height - (2 * verticalOffset);
    XRect columnRect = new XRect(horizontalOffset, verticalOffset, columnWidth, columnHeight);
    gfx.DrawRectangle(XBrushes.Teal, columnRect);
    
    // Insert an image inside the rectangle, referencing the Left and Top properties of the rectangle for image placement
    XImage topLogo = XImage.FromFile(GetFilePath(@"content\img\pdfs\standard\logo-no-strapline.jpg")); // GetFilePath is a private method, not shown for brevity
    gfx.DrawImage(topLogo,
    	columnRect.Left + XUnit.FromMillimeter(5),
    	columnRect.Top + XUnit.FromMillimeter(5),
    	columnRect.Width - XUnit.FromMillimeter(10),
    	XUnit.FromMillimeter(38));
