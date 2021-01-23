    public sealed class HomeButton : Button
    {
        public HomeButton()
        {
            this.DefaultStyleKey = this.GetType();
            this.Click += HomeButton_Click;
            this.Content = "Home";
        }
        void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            var _Frame = Window.Current.Content as Frame;
            var _Type = typeof(HomePage);
            _Frame.Navigate(_Type);
        }
    }
