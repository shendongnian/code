     public class ListItemViewModel: ViewModelBase
        {
            private string _displayName;
            public string DisplayName
            {
                get { return _displayName; }
                set
                {
                    _displayName = value;
                    NotifyPropertyChange(() => DisplayName);
                }
            }
        }
