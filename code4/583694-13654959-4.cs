        protected void tgtRect_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Zoom in when Delta is positive, Zoom out when negative
            double exp = -e.Delta / Math.Abs(e.Delta);
            double val = Math.Pow(1.1, exp);
            vBox.Scale(val, val);
            imgBrush.Viewbox = vBox;
        }
        void tgtRect_MouseMove(object sender, MouseEventArgs e)
        {
            Point thisPosition = e.GetPosition(tgtRect);
            if (e.RightButton == MouseButtonState.Pressed)
            {
                double w = tgtRect.ActualWidth;
                double h = tgtRect.ActualHeight;
                Vector offset = lastPosition - thisPosition;
                offset.X /= w;
                offset.Y /= h;
                vBox.Offset(offset);
                imgBrush.Viewbox = vBox;
            }
            lastPosition = thisPosition;
        }
