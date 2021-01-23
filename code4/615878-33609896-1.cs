        double desiredVerticalOffset = 0;
        private void SW_Handler_OnPointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint mousePosition = e.GetCurrentPoint(sender as UIElement);
            var delta = mousePosition.Properties.MouseWheelDelta;
            // calculate desiredOffset
            desiredVerticalOffset = desiredVerticalOffset + delta;
            // limit desiredOffset.
            desiredVerticalOffset = desiredVerticalOffset < 0 ? 0 : desiredVerticalOffset;
            desiredVerticalOffset = desiredVerticalOffset > _ScrollViewer.ScrollableHeight ? _ScrollViewer.ScrollableHeight : desiredVerticalOffset;
            if (delta < 0 || delta > 0)
            {
                _ScrollViewer.ChangeView(null, desiredVerticalOffset, null, false);
                e.Handled = true;
            }
        }
