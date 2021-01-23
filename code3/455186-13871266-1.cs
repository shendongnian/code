    private void NotifyPropertyChanged(String info)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (PropertyChanged != null)
        {
            if (System.Threading.Thread.CurrentThread == System.Windows.Application.Current.Dispatcher.Thread)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            else
                System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() => PropertyChanged(this,new PropertyChangedEventArgs(info));
        }
    }
