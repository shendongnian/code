    private void OnRightMouseDown(object sender, MouseButtonEventArgs e)
    {
        var uc01 = sender as UserControl01;
        if (uc01 != null)
        {
            uc01.ViewModel.IsSelected = true;
            return;
        }
        
        var uc02 = sender as UserControl02;
        if (uc02 != null)
        {
            uc02.ViewModel.IsSelected = true;
        }
    }
