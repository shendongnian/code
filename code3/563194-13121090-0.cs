     Rect bounds = VisualTreeHelper.GetDescendantBounds(surface);
                    DrawingVisual dv = new DrawingVisual();
                    using (DrawingContext ctx = dv.RenderOpen())
                    {
                        VisualBrush vb = new VisualBrush(surface);
                        ctx.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
                    }
    
                    renderBitmap.Render(dv);
