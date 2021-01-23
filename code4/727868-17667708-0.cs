     private void button_MouseEnter(object sender, MouseEventArgs e)
     {
           Button button = sender as Button;
           Style style = new System.Windows.Style(typeof(Button));
           style.Setters.Add(new Setter(Button.BackgroundProperty, Brushes.Yellow));
           button.Style = style;
           button.Background = Brushes.Yellow;
       }
