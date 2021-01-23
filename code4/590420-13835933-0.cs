    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        LoadForm lf = new LoadForm();
        lf.Visibility = Visibility.Visible;
        //start the time consuming task in another thread
    }
    HeavyTaskCompleteEvent()
    {
         lf.Close();
    }
