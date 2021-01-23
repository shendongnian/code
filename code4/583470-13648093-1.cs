        public class bbbbb : INotifyPropertyChanged
        {
            public bbbbb()
            {
                IgnoredActivities.Add("empty");
                IgnoredActivities.Add("stuff");
            }
    
            private ObservableCollection<String> _ignoredActivities;
            public ObservableCollection<String> IgnoredActivities
            {
                get
                {
                    if (_ignoredActivities == null)
                    {
                        // empty
                        _ignoredActivities = new ObservableCollection<String>() { "empty","stuff" };
                    }
                    return _ignoredActivities;
                }
            }
        
                #region INotifyPropertyChanged Members
        
                public event PropertyChangedEventHandler PropertyChanged;
                private void RaisePropertyChanged(string _Prop)
                {
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs(_Prop));
                }
        
                #endregion
        }
    }
