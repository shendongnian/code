    public BitmapSource FlowDocumentToBitmap(FlowDocument document, Size size)
    {
        var paginator = ((IDocumentPaginatorSource)document).DocumentPaginator;
        paginator.PageSize = size;
        var visual = new DrawingVisual();
        using (var drawingContext = visual.RenderOpen())
        {
            // draw white background
            drawingContext.DrawRectangle(Brushes.White, null, new Rect(size));
        }
            
        visual.Children.Add(paginator.GetPage(0).Visual);
        var bitmap = new RenderTargetBitmap((int)size.Width, (int)size.Height,
                                            96, 96, PixelFormats.Pbgra32);
        bitmap.Render(visual);
        return bitmap;
    }
