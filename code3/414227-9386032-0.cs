    public void CreateNotificationImage(string imagePath, NotificationData data)
    {
        // CreateDocument() is my own method where a new doc is created with new data
        Document doc = CreateDocument(data);
        doc.DefaultPageSetup.PageFormat = PageFormat.Letter;
        int page = 1;
        DocumentRenderer renderer = new DocumentRenderer(doc);
        renderer.PrepareDocument();
        PageInfo pageInfo = renderer.FormattedDocument.GetPageInfo(page);
        int dpi = 150;
        int dx  = (int)(pageInfo.Width.Inch * dpi);
        int dy  = (int)(pageInfo.Height.Inch * dpi);
        float scale = dpi / 72f;
        System.Drawing.Image image = new Bitmap(dx, dy, PixelFormat.Format32bppRgb);
        using (Graphics graphics = Graphics.FromImage(image))
        {
            graphics.Clear(System.Drawing.Color.White);
            graphics.ScaleTransform(scale, scale); // scale to 72dpi
            using (XGraphics gfx = XGraphics.FromGraphics(graphics, new XSize(Unit.FromInch(8.5).Point, Unit.FromInch(11).Point)))
            {
                renderer.RenderPage(gfx, page);
                WriteTiffImage(imagePath, image);
            }
        }           
    }
