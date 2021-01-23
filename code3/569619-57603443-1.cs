    public class NinePatchPanel : ContentControl
    {
        ImageSource[] patchs;
        [Category("Background")]
        [Description("Set nine patch background image")]
        public ImageSource BackgroundImage
        {
            get { return (ImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }
        public static readonly DependencyProperty BackgroundImageProperty =
            DependencyProperty.Register("BackgroundImage", typeof(ImageSource), typeof(NinePatchPanel), new PropertyMetadata(null, SetImg));
        [Category("Background")]
        [Description("Set the center split area")]
        public Int32Rect CenterArea
        {
            get { return (Int32Rect)GetValue(CenterAreaProperty); }
            set { SetValue(CenterAreaProperty, value); }
        }
        public static readonly DependencyProperty CenterAreaProperty =
            DependencyProperty.Register("CenterArea", typeof(Int32Rect), typeof(NinePatchPanel), new PropertyMetadata(Int32Rect.Empty, SetArea));
        protected override void OnRender(DrawingContext dc)
        {
            if (patchs != null)
            {
                double x1 = patchs[0].Width, x2 = Math.Max(ActualWidth - patchs[2].Width, 0);
                double y1 = patchs[0].Height, y2 = Math.Max(ActualHeight - patchs[6].Height, 0);
                double w1 = patchs[0].Width, w2 = Math.Max(x2 - x1, 0), w3 = patchs[2].Width;
                double h1 = patchs[0].Height, h2 = Math.Max(y2 - y1, 0), h3 = patchs[6].Height;
                var rects = new[]
                {
                    new Rect(0, 0, w1, h1),
                    new Rect(x1, 0, w2, h1),
                    new Rect(x2, 0, w3, h1),
                    new Rect(0, y1, w1, h2),
                    new Rect(x1, y1, w2, h2),
                    new Rect(x2, y1, w3, h2),
                    new Rect(0, y2, w1, h3),
                    new Rect(x1, y2, w2, h3),
                    new Rect(x2, y2, w3, h3)
                };
                for (int i = 0; i < 9; i++)
                {
                    dc.DrawImage(patchs[i], rects[i]);
                }
            }
            base.OnRender(dc);
        }
        private static void SetArea(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var np = d as NinePatchPanel;
            if (np == null) return;
            var bm = np.BackgroundImage as BitmapSource;
            if (bm != null) SetPatchs(np, bm);
        }
        private static void SetImg(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var np = d as NinePatchPanel;
            if (np == null) return;
            var bm = np.BackgroundImage as BitmapSource;
            if (np.CenterArea == Int32Rect.Empty)
            {
                var w1_3 = bm.PixelWidth / 3;
                var h1_3 = bm.PixelHeight / 3;
                np.CenterArea = new Int32Rect(w1_3, h1_3, w1_3, h1_3);
            }
            else
            {
                SetPatchs(np, bm);
            }
        }
        private static void SetPatchs(NinePatchPanel np, BitmapSource bm)
        {
            int x1 = np.CenterArea.X, x2 = np.CenterArea.X + np.CenterArea.Width;
            int y1 = np.CenterArea.Y, y2 = np.CenterArea.Y + np.CenterArea.Height;
            int w1 = np.CenterArea.X, w2 = np.CenterArea.Width, w3 = bm.PixelWidth - np.CenterArea.X - np.CenterArea.Width;
            int h1 = np.CenterArea.Y, h2 = np.CenterArea.Height, h3 = bm.PixelHeight - np.CenterArea.Y - np.CenterArea.Height;
            np.patchs = new[] {
                new CroppedBitmap(bm, new Int32Rect(0, 0, w1, h1)),
                new CroppedBitmap(bm, new Int32Rect(x1, 0, w2, h1)),
                new CroppedBitmap(bm, new Int32Rect(x2, 0, w3, h1)),
                new CroppedBitmap(bm, new Int32Rect(0, y1, w1, h2)),
                new CroppedBitmap(bm, new Int32Rect(x1, y1, w2, h2)),
                new CroppedBitmap(bm, new Int32Rect(x2, y1, w3, h2)),
                new CroppedBitmap(bm, new Int32Rect(0, y2, w1, h3)),
                new CroppedBitmap(bm, new Int32Rect(x1, y2, w2, h3)),
                new CroppedBitmap(bm, new Int32Rect(x2, y2, w3, h3))
            };
        }
    }
