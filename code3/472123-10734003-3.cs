    lstMetricUnit.Dispatcher.Invoke(
              System.Windows.Threading.DispatcherPriority.Normal,
              new Action(
                delegate()
                {
                  lstMetricUnit.ItemsSource = null;
                  lstMetricUnit.ItemsSource = MetricUnits;   
                }
            ));
