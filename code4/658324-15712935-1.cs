    private delegate void UpdateProgressBarDelegate(
        System.Windows.DependencyProperty dp, Object value);
    private void startProgessBar(string controlname)
    {
        MclarenServerCecksProgressBar.Visibility = Visibility.Visible;
    
    
        //Stores the value of the ProgressBar
    
        //Create a new instance of our ProgressBar Delegate that points
        // to the ProgressBar's SetValue method.
        UpdateProgressBarDelegate updatePbDelegate =
            new UpdateProgressBarDelegate(MclarenServerCecksProgressBar.SetValue);
        bool _status = true;
        int flag = 0;
        double value = 0;
    
        do
        {
    
            /*Update the Value of the ProgressBar: */
    
            Dispatcher.Invoke(updatePbDelegate,
                System.Windows.Threading.DispatcherPriority.Background,
                new object[] { System.Windows.Controls.ProgressBar.ValueProperty, value });
    
    
                    if (flag == 0)
                    {
                        flag == 1
                        _status = processesServices(controlname);
                    }
                    if (_status == false)
                    {
                        MclarenServerCecksProgressBar.Visibility = Visibility.Hidden;
                    }
        }
        while (_status);
    }
