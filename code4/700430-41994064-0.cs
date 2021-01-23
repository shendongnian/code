    public class Entity: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public Entity()
            {
                Selected = false;
            }
            
            private bool _selected;
            public bool Selected
            {
                get
                {
                    return _selected;
                }
                set
                {
                    if (_selected != value)
                    {
                        _selected = value;
                        OnPropertyChanged(nameof(Selected));
                    }
                }
            }
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
