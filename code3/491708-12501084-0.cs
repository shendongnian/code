            DesignerItem designerItem = this.DataContext as DesignerItem;
            DesignerCanvas designer = VisualTreeHelper.GetParent(designerItem) as DesignerCanvas;
            if (designerItem != null && designer != null && designerItem.IsSelected)
            {
                double minLeft = double.MaxValue;
                double minTop = double.MaxValue;
                // we only move DesignerItems
                var designerItems = designer.SelectionService.CurrentSelection.OfType<DesignerItem>();
                foreach (DesignerItem item in designerItems)
                {
                    double left = Canvas.GetLeft(item);
                    double top = Canvas.GetTop(item);
                    minLeft = double.IsNaN(left) ? 0 : Math.Min(left, minLeft);
                    minTop = double.IsNaN(top) ? 0 : Math.Min(top, minTop);
                }
                double deltaHorizontal = Math.Max(-minLeft, e.HorizontalChange);
                double deltaVertical = Math.Max(-minTop, e.VerticalChange);
                foreach (DesignerItem item in designerItems)
                {
                    RotateTransform rotateTransform = designerItem.RenderTransform as RotateTransform;
                    double left = Canvas.GetLeft(item);
                    double top = Canvas.GetTop(item);
                    if (double.IsNaN(left)) left = 0;
                    if (double.IsNaN(top)) top = 0;
                    if (rotateTransform != null)
                    {
                        Point dragDelta = new Point(e.HorizontalChange, e.VerticalChange);
                        dragDelta = rotateTransform.Transform(dragDelta);
                        Canvas.SetLeft(item, left + dragDelta.X);
                        Canvas.SetTop(item, top+ dragDelta.Y);
                    }
                    else
                    {
                        Canvas.SetLeft(item, left + deltaHorizontal);
                        Canvas.SetTop(item, top + deltaVertical);
                    }
                }
                designer.InvalidateMeasure();
                e.Handled = true;
            }
        }
