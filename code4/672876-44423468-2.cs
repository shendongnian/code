    using SD = System.Drawing;  // so we don't collide with WPF
    public class CustomControl : Image
    { 
        static double WPF_DPI = 97;
        WriteableBitmap backingStore;
        public CustomControl() {
            backingStore = 
               new WriteableBitmap(
                   500,500,
                   WPF_DPI,WPF_DPI,
                   PixelFormats.Bgr24,null);
            Redraw();
            Source = backingStore;
            SizeChanged += CustomControl_SizeChanged;
            // if you want to render every frame, catch the
            // CompositionTarget.Rendering event
        }
        private void CustomControl_SizeChanged(object sender, EventArgs e) {            
            if (RenderSize.Width != backingStore.PixelWidth ||
                RenderSize.Height != backingStore.PixelHeight) {
                if (RenderSize.Height == 0 && RenderSize.Width == 0) {
                    Source = backingStore = null;
                } else {
                    backingStore = 
                        new WriteableBitmap(
                              (int)RenderSize.Width, 
                              (int)RenderSize.Height, 
                              WPF_DPI, WPF_DPI, 
                              PixelFormats.Bgr24, null);
                    Redraw();
                    Source = backingStore;  
                }
            }
        }
        private void Redraw() {
            var wb = backingStore;
            if (wb == null) { return; } // nothing to do
            wb.Lock();
            var bmp = new SD.Bitmap(
                wb.PixelWidth, wb.PixelHeight,
                wb.BackBufferStride,                                                 
                SD.Imaging.PixelFormat.Format24bppRgb,
                wb.BackBuffer);
            SD.Graphics g = SD.Graphics.FromImage(bmp); // Good old Graphics
            try {
                var size = new SD.Size(wb.PixelWidth,wb.PixelHeight);
                Redraw(size,g);
            } finally {
            
                g.Dispose();
                bmp.Dispose();
                wb.AddDirtyRect(
                    new Int32Rect(0,0,
                         wb.PixelWidth,wb.PixelHeight));
                wb.Unlock();
            }
        } 
        
        private void Redraw(SD.Size size, SD.Graphics g) {
            // your GDI drawing code goes here...
            // for example:
            g.FillRectangle(
                 SD.Brushes.Red, 
                 new SD.Rectangle(0,0,size.Width,size.Height));
        }
    }
