        /// <summary>
        /// Defines a thumb for resizing shapes.
        /// </summary>
        public class ResizeThumb : Thumb
        {  
        /// <summary>
        /// Holds a designer item.
        /// </summary>
        private DesignerItem _designerItem;
        /// <summary>
        /// Holds a collection of designer items.
        /// </summary>
        private DesignerItems _designerItems;
        /// <summary>
        /// holds a transform origin of the designer item 
        /// </summary>
        private Point _transformOrigin;
        /// <summary>
        /// holds an angle of the rotation transformation of the designer item
        /// </summary>
        private double _angle = 0.0;
        /// <summary>
        /// Initializes a new instance of the <see cref="ResizeThumb"/> class.
        /// </summary>
        public ResizeThumb()
        {
            DragStarted += ResizeThumbDragStarted;
            DragDelta += ResizeThumbDragDelta;
            DragCompleted += ResizeThumbDragCompleted;
        }
        /// <summary>
        /// Handles notifications when the dragging of the thumb starts.
        /// </summary>
        /// <param name="sender">the sender object</param>
        /// <param name="e">the event arguments</param>
        private void ResizeThumbDragStarted(object sender, DragStartedEventArgs e)
        {
            _designerItem = DataContext as DesignerItem;
            if (_designerItem == null) 
                return;
            _designerItem.IsResizing = true;
            _designerItem.IsDragging = true;
            _designerItems = _designerItem.GetItemsControl();
            
            _transformOrigin = _designerItem.RenderTransformOrigin;            
            var rotateTransform = _designerItem.RenderTransform as RotateTransform;
            if (rotateTransform != null)
                _angle = rotateTransform.Angle * Math.PI / 180.0;
            else
                _angle = 0.0;
        }
        /// <summary>
        /// Handles notifications when the dragging of the thumb completes.
        /// </summary>
        /// <param name="sender">the sender object</param>
        /// <param name="e">the event arguments</param>
        private void ResizeThumbDragCompleted(object sender, DragCompletedEventArgs e)
        {
            if (_designerItem != null)
            {
                _designerItem.IsResizing = false;
                _designerItem.IsDragging = false;
            }
        }
        /// <summary>
        /// Handles notifications when the thumb has been dragged.
        /// </summary>
        /// <param name="sender">the sender object</param>
        /// <param name="e">the event arguments</param>
        private void ResizeThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            if (_designerItem == null ||
                _designerItems == null ||
                !_designerItem.IsSelected)
            {
                return;
            }
            var item = _designerItem;
            var minLeft = double.MaxValue;
            var minTop = double.MaxValue;
            var minDeltaHorizontal = double.MaxValue;
            var minDeltaVertical = double.MaxValue;
            
            minLeft = Math.Min(Canvas.GetLeft(item), minLeft);
            minTop = Math.Min(Canvas.GetTop(item), minTop);
            minDeltaVertical = Math.Min(minDeltaVertical, item.ActualHeight - item.MinHeight);
            minDeltaHorizontal = Math.Min(minDeltaHorizontal, item.ActualWidth - item.MinWidth);
            // stop moving when
            // at least one of the selected items is locked
            if (item.IsLocked)
            {
                return;
            }
            double? dragDeltaVertical = null;
            switch (VerticalAlignment)
            {
                case VerticalAlignment.Bottom:
                    dragDeltaVertical = Math.Min(-e.VerticalChange, minDeltaVertical);
                    break;
                case VerticalAlignment.Top:
                    dragDeltaVertical = Math.Min(Math.Max(-minTop, e.VerticalChange), minDeltaVertical);
                    break;
            }
            double? dragDeltaHorizontal = null;
            switch (HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    dragDeltaHorizontal = Math.Min(Math.Max(-minLeft, e.HorizontalChange), minDeltaHorizontal);
                    break;
                case HorizontalAlignment.Right:
                    dragDeltaHorizontal = Math.Min(-e.HorizontalChange, minDeltaHorizontal);
                    break;
            }
            // in case the aspect ratio is kept then adjust both width and height
            if (item.KeepAspectRatio)
            {
                CheckAspectRatio(ref dragDeltaHorizontal, ref dragDeltaVertical, item.ActualHeight / item.ActualWidth);
            }
            if (dragDeltaVertical.HasValue)
            {
                switch (VerticalAlignment)
                {
                    case System.Windows.VerticalAlignment.Bottom:
                        Canvas.SetTop(item, Canvas.GetTop(item) + (_transformOrigin.Y * dragDeltaVertical.Value * (1 - Math.Cos(-_angle))));
                        Canvas.SetLeft(item, Canvas.GetLeft(item) - dragDeltaVertical.Value * _transformOrigin.Y * Math.Sin(-_angle));
                        break;
                    case System.Windows.VerticalAlignment.Top:
                        Canvas.SetTop(item, Canvas.GetTop(item) + dragDeltaVertical.Value * Math.Cos(-_angle) + (_transformOrigin.Y * dragDeltaVertical.Value * (1 - Math.Cos(-_angle))));
                        Canvas.SetLeft(item, Canvas.GetLeft(item) + dragDeltaVertical.Value * Math.Sin(-_angle) - (_transformOrigin.Y * dragDeltaVertical.Value * Math.Sin(-_angle)));
                        break;
                    default:
                        break;
                }
                item.Height = item.ActualHeight - dragDeltaVertical.Value;
            }
            if (dragDeltaHorizontal.HasValue)
            {
                switch (HorizontalAlignment)
                {
                    case System.Windows.HorizontalAlignment.Left:
                        Canvas.SetTop(item, Canvas.GetTop(item) + dragDeltaHorizontal.Value * Math.Sin(_angle) - _transformOrigin.X * dragDeltaHorizontal.Value * Math.Sin(_angle));
                        Canvas.SetLeft(item, Canvas.GetLeft(item) + dragDeltaHorizontal.Value * Math.Cos(_angle) + (_transformOrigin.X * dragDeltaHorizontal.Value * (1 - Math.Cos(_angle))));
                        break;
                    case System.Windows.HorizontalAlignment.Right:
                        Canvas.SetTop(item, Canvas.GetTop(item) - _transformOrigin.X * dragDeltaHorizontal.Value * Math.Sin(_angle));
                        Canvas.SetLeft(item, Canvas.GetLeft(item) + (dragDeltaHorizontal.Value * _transformOrigin.X * (1 - Math.Cos(_angle))));
                        break;
                    default:
                        break;
                }
                item.Width = item.ActualWidth - dragDeltaHorizontal.Value;
            }
            e.Handled = true;
        }
        /// <summary>
        /// Checks the values so that the ratio beween them has a defined value.
        /// </summary>
        /// <param name="dragDeltaHorizontal">horizontal delta</param>
        /// <param name="dragDeltaVertical">vertical delta</param>
        /// <param name="aspectRatio">horizontal to vertical ration</param>
        private void CheckAspectRatio(ref double? dragDeltaHorizontal, ref double? dragDeltaVertical, double aspectRatio)
        {
            double? dragValue = null;
            if (dragDeltaVertical.HasValue && dragDeltaHorizontal.HasValue)
            {
                dragValue = Math.Max(dragDeltaVertical.Value, dragDeltaHorizontal.Value);
            }
            else if (dragDeltaVertical.HasValue)
            {
                dragValue = dragDeltaVertical;
            }
            else if (dragDeltaHorizontal.HasValue)
            {
                dragValue = dragDeltaHorizontal;
            }
            if (dragValue.HasValue)
            {
                dragDeltaVertical = dragValue.Value * aspectRatio;
                dragDeltaHorizontal = dragValue;
            }
        }
        }
