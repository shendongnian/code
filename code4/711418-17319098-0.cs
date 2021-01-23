        private double Interpolate(double x0, double y0, double x1, double y1, double x)
        {
            return y0 * (x - x1) / (x0 - x1) + y1 * (x - x0) / (x1 - x0);
        }
        private void mapZoom_Event(object sender, ViewChangedEventArgs e)
        {
            double scale;
            foreach (Pushpin currentPin in currentPins)
            {
                double zoom = Map.ZoomLevel;
                scale = interpolate(10, 1 / 2, 18, 3, zoom);
                if (scale < 1)
                    scale = 1;
                ScaleTransform pushpinsScaleTransform = new ScaleTransform()
                {
                    ScaleX = scale,
                    ScaleY = scale
                };
                currentPin.RenderTransform = pushpinsScaleTransform;
            }
        }
