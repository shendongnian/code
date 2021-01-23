    if (lstMetricUnit.InvokeRequired)
    {        
        // Execute the specified delegate on the thread that owns
        // 'lstMetricUnit' control's underlying window handle.
        lstMetricUnit.Invoke(lstMetricUnit.myDelegate);        
    }
    else
    {
        lstMetricUnit.ItemsSource = null;
        lstMetricUnit.ItemsSource = MetricUnits;
    }
