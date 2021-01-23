    public class ZoomCanvas : Canvas
    {
        public static readonly DependencyProperty ChildPositionTransformProperty =
            DependencyProperty.Register(
                "ChildPositionTransform", typeof(Transform), typeof(ZoomCanvas),
                new FrameworkPropertyMetadata(
                    Transform.Identity, FrameworkPropertyMetadataOptions.AffectsArrange));
        public Transform ChildPositionTransform
        {
            get { return (Transform)GetValue(ChildPositionTransformProperty); }
            set { SetValue(ChildPositionTransformProperty, value); }
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement element in InternalChildren)
            {
                var x = GetLeft(element);
                var y = GetTop(element);
                var pos = new Point(double.IsNaN(x) ? 0d : x, double.IsNaN(y) ? 0d : y);
                ArrangeElement(element, ChildPositionTransform.Transform(pos));
            }
            return finalSize;
        }
        private void ArrangeElement(UIElement element, Point position)
        {
            element.Arrange(new Rect(position, element.DesiredSize));
        }
    }
