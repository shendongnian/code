        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            new ToastPrompt()
            {
                Title = "hello world",
                Message = "sup stackoverflow?"
            }.Show();
        }
