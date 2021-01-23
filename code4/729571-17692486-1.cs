        private void GestureListener_DragDelta_1(object sender, Microsoft.Phone.Controls.DragDeltaGestureEventArgs e)
        {
            img1gesture.TranslateX += e.HorizontalChange;
            img2gesture.TranslateX += e.HorizontalChange;
            img1gesture.TranslateY += e.VerticalChange;
            img2gesture.TranslateY += e.VerticalChange;
        }
