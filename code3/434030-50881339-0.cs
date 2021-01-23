        using System.Windows.Data;
  
        private readonly object _lock = new object();
        private CustomObservableCollection<string> _myUiBoundProperty;
        public CustomObservableCollection<string> MyUiBoundProperty
        {
            get { return _myUiBoundProperty; }
            set
            {
                if (value == _myUiBoundProperty) return;
                _myUiBoundProperty = value;
                NotifyPropertyChanged(nameof(MyUiBoundProperty));
            }
        }
        public MyViewModelCtor(INavigationService navigationService) 
        {
           // Other code...
           BindingOperations.EnableCollectionSynchronization(AvailableDefectSubCategories, _lock );
        }
