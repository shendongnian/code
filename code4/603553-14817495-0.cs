    internal sealed class DragAdorner : Adorner
    {
       private readonly UIElement _child;
       private readonly double _xCenter;
       private readonly double _yCenter;
       private double _leftOffset;
       private double _topOffset;
    
       public DragAdorner(UIElement owner, UIElement child, bool useVisualBrush, double opacity) : base(owner)
       {
          if (!useVisualBrush)
          {
             _child = child;
          }
          else
          {
             var size = GetRealSize(child);
             _xCenter = size.Width / 2;
             _yCenter = size.Height / 2;
    
             _child = new Rectangle
             {
                RadiusX = 3,
                RadiusY = 3,
                Width = size.Width,
                Height = size.Height,
                Fill = new VisualBrush(child)
                {
                   Opacity = opacity,
                   AlignmentX = AlignmentX.Left,
                   AlignmentY = AlignmentY.Top,
                   Stretch = Stretch.None,
                },
             };
          }
       }
    
       protected override int VisualChildrenCount
       {
          get { return 1; }
       }
    
       public double LeftOffset
       {
          get
          {
             return _leftOffset + _xCenter;
          }
          set
          {
             _leftOffset = value - _xCenter;
             UpdatePosition();
          }
       }
    
       public double TopOffset
       {
          get
          {
             return _topOffset + _yCenter;
          }
          set
          {
             _topOffset = value - _yCenter;
             UpdatePosition();
          }
       }
    
       private static Size GetRealSize(UIElement child)
       {
          return child == null ? Size.Empty : child.RenderSize;
       }
    
       public void UpdatePosition(Point point)
       {
          _leftOffset = point.X;
          _topOffset = point.Y;
          UpdatePosition();
       }
    
       public void UpdatePosition()
       {
          var adorner = Parent as AdornerLayer;
          if (adorner != null) adorner.Update(AdornedElement);
       }
    
       protected override Visual GetVisualChild(int index)
       {
          if (0 != index) throw new ArgumentOutOfRangeException("index");
          return _child;
       }
    
       protected override Size MeasureOverride(Size availableSize)
       {
          _child.Measure(availableSize);
          return _child.DesiredSize;
       }
    
       protected override Size ArrangeOverride(Size finalSize)
       {
          _child.Arrange(new Rect(_child.DesiredSize));
          return finalSize;
       }
    
       public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
       {
          var result = new GeneralTransformGroup();
          result.Children.Add(new TranslateTransform(_leftOffset, _topOffset));
    
          var baseTransform = base.GetDesiredTransform(transform);
          if (baseTransform != null) result.Children.Add(baseTransform);
    
          return result;
       }
    }
