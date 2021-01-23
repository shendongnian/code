    public class CustomControl : Image
    { 
        static double WPF_DPI = 97;
        RenderTargetBitmap backingStore;
        public CustomControl() {
            backingStore = 
                 new RenderTargetBitmap(200, 200, 
                      WPF_DPI, WPF_DPI, PixelFormats.Pbgra32);
            SizeChanged += CustomControl_SizeChanged;
            // if you want to render every frame, catch the
            // CompositionTarget.Rendering event
        }
        private void CustomControl_SizeChanged(object sender,
                                      SizeChangedEventArgs e) {
            if (RenderSize.Width == 0) {
                Source = backingStore = null;
            } else {
                Source = backingStore = 
                    new RenderTargetBitmap(
                            (int)RenderSize.Width, 
                            (int)RenderSize.Height, 
                            WPF_DPI, WPF_DPI, 
                            PixelFormats.Pbgra32);
            }
        }
        private void Render() {
            var drawingVisual = new DrawingVisual();
            var drawingContext = drawingVisual.RenderOpen();
            try {
                Render(drawingContext);
            } finally {
                drawingContext.Close();
                backingStore.Render(drawingVisual);
            }
        }
        private void Render(DrawingContext drawingContext) {
            // put your drawing commands here..
            drawingContext.DrawRectangle(
                Brushes.Red, new Pen(),
                new Rect(this.RenderSize));
        }
    }
