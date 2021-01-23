    namespace TryingWPFWithUltimate
    {
        class ViewModel:INotifyPropertyChanged
        {    
            private DatabaseContext _databaseContext;
    
            public ViewModel()
            {
                DatabaseContext = new DatabaseContext();
                Schools = new ObservableCollection<School>(DatabaseContext.Schools);
            }
            
            public ObservableCollection<School> Schools { get; set; }
        }
    }
