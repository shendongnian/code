            private ObservableCollection<MyItemType> _mainCollection;
            public ObservableCollection<MyItemType> MainCollection
            {
                get
                {
                    return _mainCollection;
                }
                set
                {
                    _mainCollection = value;
                    TriggerMyEvent(); // do whatever you like here
                }
            }
