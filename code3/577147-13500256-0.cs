      private class ErrorHighlightAdorner : Adorner
      {
          public ErrorHighlightAdorner(UIElement adornedElement)
              : base(adornedElement)
          {
          }
          protected override void OnRender(DrawingContext drawingContext)
          {
              Rect sourceRect = new Rect();
              FrameworkElement fe = AdornedElement as FrameworkElement;
              if (fe != null)
              {
                  sourceRect = new Rect(fe.RenderSize);
              }
              else
              {
                  sourceRect = new Rect(AdornedElement.DesiredSize);
              }
              Pen renderPen = new Pen(new SolidColorBrush(Colors.Red), 2.0);
              drawingContext.DrawRectangle(null, renderPen, sourceRect);
          }
      }
