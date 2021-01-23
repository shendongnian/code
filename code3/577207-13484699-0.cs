     bool toggle = false;
     private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
     {
         rect.Fill = new SolidColorBrush(toggle ? Colors.Aquamarine : Colors.DarkRed);
         toggle = !toggle;
     }
