        private int _itemsCount;
        private RelayCommand<int> _selectionChangedCommand;
        
        public ICommand SelectionChangedCommand
        {
           get {
                    return _selectionChangedCommand ?? (_selectionChangedCommand = 
                 new RelayCommand<int>((itemsCount) => { ItemsCount = itemsCount; }));
               }
        }
            
            public int ItemsCount
            {
                get { return _itemsCount; }
                set { 
                  _itemsCount = value;
                  OnPropertyChanged("ItemsCount");
                 }
            }
