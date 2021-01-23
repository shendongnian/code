    private void ButtonClick(object sender, System.Windows.RoutedEventArgs e)
    {
        Hat newHat = new Hat { Name = "hat 2", Color = "Red" };
    
        var viewModel = (ViewModel)DataContext;
    
        var oldHat = viewModel.Collection[1];
    
        if (viewModel.SelectedHat == oldHat)
        {
            viewModel.Collection.Add(newHat);
            viewModel.SelectedHat = newHat;
            viewModel.Collection.Remove(oldHat);
        }
        else
        {
            viewModel.Collection[1] = newHat;
        }
    }
