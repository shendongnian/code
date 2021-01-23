        private void txt1_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            GeneralTransform gt = t.TransformToVisual(Application.Current.RootVisual);
            Point offset = gt.Transform(new Point(0, 0));
            double controlTop = offset.Y;
            double controlLeft = offset.X;
        }
