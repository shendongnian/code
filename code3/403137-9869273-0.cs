    public class MyDrawingView : FrameworkElement
    {
        List<DrawingVisual> _visuals = new List<DrawingVisual>();
    
        public MyDrawingView()
        {
            CreateVisuals();
        }
    
        protected override int VisualChildrenCount
        {
            get
            {
                return _visuals.Count;
            }
        }
    
        protected override Visual GetVisualChild(int index)
        {
            return _visuals[index];
        }
    
        private void CreateVisuals()
        {
            CreateVisualForBitmap(@"D:\mytemp\img1.jpg", new Rect(50, 50, 100, 100));
            CreateVisualForBitmap(@"D:\mytemp\img2.jpg", new Rect(30, 30, 100, 100));
        }
    
        private void CreateVisualForBitmap(string bitmapPath, Rect bounds)
        {
            var bitmap    = new BitmapImage(new Uri(bitmapPath));
            var visual    = new DrawingVisual();
            visual.Effect = new DropShadowEffect();
    
            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawImage(bitmap, bounds);
            }
    
            _visuals.Add(visual);
            AddVisualChild(visual);
            AddLogicalChild(visual);
        }
    }
