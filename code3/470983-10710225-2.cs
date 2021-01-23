    private void Token_DoubleTap(object sender, GestureEventArgs e)
        {
            var token = (sender as StackPanel).Tag as ItemViewModel;
            App.ViewModel.Items.Remove(token);
            App.ViewModel.Items2.Add(token);
        }
