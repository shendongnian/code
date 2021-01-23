    public class ZoomCanvas : Canvas
    {
        public static readonly DependencyProperty ChildTransformProperty =
            DependencyProperty.Register(
                "ChildTransform", typeof(Transform), typeof(ZoomCanvas),
                new FrameworkPropertyMetadata(
                    Transform.Identity, FrameworkPropertyMetadataOptions.AffectsArrange));
        public Transform ChildTransform
        {
            get { return (Transform)GetValue(ChildTransformProperty); }
            set { SetValue(ChildTransformProperty, value); }
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement element in InternalChildren)
            {
                var x = GetLeft(element);
                var y = GetTop(element);
                var pos = new Point(double.IsNaN(x) ? 0d : x, double.IsNaN(y) ? 0d : y);
                var rect = new Rect(ChildTransform.Transform(pos), element.DesiredSize);
                element.Arrange(rect);
            }
            return finalSize;
        }
    }
