        private void ChangeResource_Click(object sender, RoutedEventArgs e)
        {
            Color MyCodeColor = Colors.BlanchedAlmond;
            SolidColorBrush MyBrush = Brushes.Aquamarine;
            // Set the new value
            Application.Current.Resources["MyColor"] = MyCodeColor;
            Application.Current.Resources["MyColor2"] = MyBrush;
        }	
