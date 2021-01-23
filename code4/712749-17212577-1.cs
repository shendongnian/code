    private void UserControl01_RightMouseDown(object sender, MouseButtonEventArgs e)
    {
        ((UserControl01)sender).ViewModel.IsSelected = true;
    }
        
    private void UserControl02_RightMouseDown(object sender, MouseButtonEventArgs e)
    {
        ((UserControl02)sender).ViewModel.IsSelected = true;
    }
