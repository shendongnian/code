    private void playersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender.GetType() == typeof(ListView))
        {
            (sender as ListView).SelectedIndex = GameObserver.Instance.core.SelectedIndex;
            e.Handled = true;
        }
    }
