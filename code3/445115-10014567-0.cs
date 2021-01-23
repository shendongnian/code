    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        {
            _doubleDisplayValue = originalValue;
            NotifyPropertyChanged("DoubleDisplayValue");
        }), DispatcherPriority.ContextIdle, null);
