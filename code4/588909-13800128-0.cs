        protected override void OnStartup(StartupEventArgs e)
        {
            EventManager.RegisterClassHandler(typeof(Button), ButtonBase.ClickEvent, new RoutedEventHandler(ButtonClick));
             //...
         }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender != null && sender is Button)
            {
                (sender as Button).Focus();
            }
        }
