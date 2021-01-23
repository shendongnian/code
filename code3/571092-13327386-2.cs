    private void btnLogFile_MouseEnter(object sender, MouseEventArgs e)
        {
            popLogFile.DataContext = (sender as FrameworkElement).DataContext;
            popLogFile.PlacementTarget = (sender as UIElement);
            popLogFile.IsOpen = true;
            popLogFile.StaysOpen = false;
        }
