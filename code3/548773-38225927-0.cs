        TaskCompletionSource<bool> tsc = null;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            tsc = new TaskCompletionSource<bool>();
            await tsc.Task;
            WelcomeTitle.Text = "Finished work";
        }
        
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            tsc?.TrySetResult(true);
        }
