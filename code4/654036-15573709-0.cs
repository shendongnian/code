        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                 Button btn = (Button)sender;
                 Point renderedLocation = btn.TranslatePoint(new Point(0, 0), this);
            }
        }
