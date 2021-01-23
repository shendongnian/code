    private void StackPanel_Hold(object sender, GestureEventArgs e)
    {
        ItemViewModel itemViewModel = (sender as StackPanel).DataContext as ItemViewModel;
        string t = itemViewModel.LineOne;
    }
