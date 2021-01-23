        protected override void OnStartup(StartupEventArgs e)
        {
            EventManager.RegisterClassHandler(
                typeof(Button), 
                ButtonBase.ClickEvent, 
                new RoutedEventHandler(
                    (sender, args) =>
                        {
                            if (sender != null && sender is Button)
                            {
                                (sender as Button).Focus();
                            }
                        }));
         }
