    public class CustomControl : Border
    {
        Label theLabel = new Label {Content="LableText" };
        TextBox theTextbox = new TextBox {MinWidth=100 };
        public CustomControl()
        {
            StackPanel sp = new StackPanel { Orientation=Orientation.Horizontal};
            this.Child = sp;
            sp.Children.Add(theLabel);
            sp.Children.Add(theTextbox);
            theTextbox.GotFocus += new RoutedEventHandler(tb_GotFocus);
            theTextbox.LostFocus += new RoutedEventHandler(tb_LostFocus);
        }
        void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            theLabel.Background = Brushes.Yellow;
        }
        void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            theLabel.Background = Brushes.Transparent;
        }
    }
