    void Window_Closing(object sender, CancelEventArgs e)
    {
         MessageBoxResult result = MessageBox.Show(
                "msg", 
                "title", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                // If user doesn't want to close, cancel closure
                e.Cancel = true;
            }        
    }
