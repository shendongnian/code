        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
        if (this.designerItem != null)
        {
            double deltaVertical, deltaHorizontal;
            
            // 1. calculate the deltas
            switch (VerticalAlignment)
            {
                case System.Windows.VerticalAlignment.Bottom:
                    deltaVertical = Math.Min(-e.VerticalChange, this.designerItem.ActualHeight - this.designerItem.MinHeight);
                    break;
                case System.Windows.VerticalAlignment.Top:
                    deltaVertical = Math.Min(e.VerticalChange, this.designerItem.ActualHeight - this.designerItem.MinHeight);
                    break;
                default:
                    break;
            }
            switch (HorizontalAlignment)
            {
                case System.Windows.HorizontalAlignment.Left:
                    deltaHorizontal = Math.Min(e.HorizontalChange, this.designerItem.ActualWidth - this.designerItem.MinWidth);
                    break;
                case System.Windows.HorizontalAlignment.Right:
                    deltaHorizontal = Math.Min(-e.HorizontalChange, this.designerItem.ActualWidth - this.designerItem.MinWidth);
                    break;
                default:
                    break;
            }
            
            // 2. Apply the aspect ratio
            if (designerItem.KeepAspectRatio)
            {
                var dragValue = Math.Max(deltaVertical, deltaHorizontal);
                var aspectRatio = designerItem.ActualHeight / designerItem.ActualWidth;
                deltaVertical = dragValue * aspectRatio;
                deltaHorizontal = dragValue;
            }
            // 3. Update the position and size of the designer item
            switch (VerticalAlignment)
            {
                case System.Windows.VerticalAlignment.Bottom:
                    Canvas.SetTop(this.designerItem, Canvas.GetTop(this.designerItem) + (this.transformOrigin.Y * deltaVertical * (1 - Math.Cos(-this.angle))));
                    Canvas.SetLeft(this.designerItem, Canvas.GetLeft(this.designerItem) - deltaVertical * this.transformOrigin.Y * Math.Sin(-this.angle));
                    this.designerItem.Height -= deltaVertical;
                    break;
                case System.Windows.VerticalAlignment.Top:
                    Canvas.SetTop(this.designerItem, Canvas.GetTop(this.designerItem) + deltaVertical * Math.Cos(-this.angle) + (this.transformOrigin.Y * deltaVertical * (1 - Math.Cos(-this.angle))));
                    Canvas.SetLeft(this.designerItem, Canvas.GetLeft(this.designerItem) + deltaVertical * Math.Sin(-this.angle) - (this.transformOrigin.Y * deltaVertical * Math.Sin(-this.angle)));
                    this.designerItem.Height -= deltaVertical;
                    break;
                default:
                    break;
            }
            switch (HorizontalAlignment)
            {
                case System.Windows.HorizontalAlignment.Left:
                    Canvas.SetTop(this.designerItem, Canvas.GetTop(this.designerItem) + deltaHorizontal * Math.Sin(this.angle) - this.transformOrigin.X * deltaHorizontal * Math.Sin(this.angle));
                    Canvas.SetLeft(this.designerItem, Canvas.GetLeft(this.designerItem) + deltaHorizontal * Math.Cos(this.angle) + (this.transformOrigin.X * deltaHorizontal * (1 - Math.Cos(this.angle))));
                    this.designerItem.Width -= deltaHorizontal;
                    break;
                case System.Windows.HorizontalAlignment.Right:
                    Canvas.SetTop(this.designerItem, Canvas.GetTop(this.designerItem) - this.transformOrigin.X * deltaHorizontal * Math.Sin(this.angle));
                    Canvas.SetLeft(this.designerItem, Canvas.GetLeft(this.designerItem) + (deltaHorizontal * this.transformOrigin.X * (1 - Math.Cos(this.angle))));
                    this.designerItem.Width -= deltaHorizontal;
                    break;
                default:
                    break;
            } 
          } 
          }
