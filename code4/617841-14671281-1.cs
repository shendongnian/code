        private void GestureListener_DragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            TranslateX += e.HorizontalChange;
            TranslateY += e.VerticalChange;
            e.Handled = true;
        }
        private void GestureListener_PinchDelta(object sender, PinchGestureEventArgs e)
        {
            ScaleXY = e.DistanceRatio;
            e.Handled = true;
        }
