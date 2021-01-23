    public class CustomRichTextBox : RichTextBox
    {
        private bool isDragging = false;
        private Point draggingPoint;
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            bool isDragAllowed = false;
            Point pt = e.GetPosition(this);
            if (pt.Y >= 0 && pt.Y <= this.BorderThickness.Top)
                // Allow dragging if the mouse is down on the top border
                isDragAllowed = true;
            else if (pt.Y >= (this.RenderSize.Height - this.BorderThickness.Bottom) && pt.Y <= this.RenderSize.Height)
                // Allow dragging if the mouse is down on the bottom border
                isDragAllowed = true;
            else if (pt.X >= 0 && pt.X <= this.BorderThickness.Left)
                // Allow dragging if the mouse is down on the left border
                isDragAllowed = true;
            else if (pt.X >= (this.RenderSize.Width - this.BorderThickness.Right) && pt.X <= this.RenderSize.Width)
                // Allow dragging if the mouse is down on the right border
                isDragAllowed = true;
            if (!isDragAllowed)
                return;
            draggingPoint = pt;
            this.CaptureMouse();
            isDragging = true;
        }
        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);
            if (isDragging)
            {
                CustomRichTextBox elem = this;
                TransformGroup ct = new TransformGroup();
                UIElement parent = (UIElement)elem.Parent;
                TranslateTransform tr = new TranslateTransform(
                    e.GetPosition(parent).X - elem.RenderSize.Width + this.BorderThickness.Left - draggingPoint.X,
                    e.GetPosition(parent).Y - elem.RenderSize.Height + this.BorderThickness.Top - draggingPoint.Y);
                ct.Children.Add(tr);
                elem.RenderTransform = ct;
            }
        }
        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonUp(e);
            isDragging = false;
            this.ReleaseMouseCapture();
        }
    }
