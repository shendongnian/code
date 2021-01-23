    <CheckBox x:Name="chbRemember1"  IsChecked="{Binding Path=RememberUser, Mode=TwoWay}"/>
    public class SessionData: INotifyPropertyChanged
        {
    
     public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string info)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
    
    
            bool _rememberUser; 
            public bool RememberUser
            {
                get 
                {
                    return _rememberUser; 
                }
                set
                {
                    _rememberUser= value;
                    NotifyPropertyChanged("RememberUser");
                }
            }
    }
