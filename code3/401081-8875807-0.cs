        private void RectView_Tap(object sender, GestureEventArgs e)
        {
            if (Click != null)
                Click(this, new RoutedEventArgs());
        }
