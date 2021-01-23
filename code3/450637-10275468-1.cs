    public decimal Col1
    {
        get { return _Col1; }
        set
        {
            //Change the property value based on condition
            _Col1 = value > 100 ? 100 : value;
            UpdateSum();
            //HACK: Simulate that the property change not fired from the setter
            Dispatcher.CurrentDispatcher
                .BeginInvoke(new Action(() => NotifyPropertyChanged("Col1")));
            //HACK: Cancel the bindig based on condition
            if (value > 100)
                throw new Exception();
        }
    }
