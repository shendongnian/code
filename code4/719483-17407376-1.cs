    using System.Collections.ObjectModel;
    namespace TryingWPFWithUltimate
    {
        class ViewModel:INotifyPropertyChanged
        {    
            private DatabaseContext _databaseContext;
    
            public ViewModel()
            {
                _databaseContext = new DatabaseContext();
                Schools = new ObservableCollection<School>(_databaseContext.Schools);
            }
            
            public ObservableCollection<School> Schools { get; set; }
        }
    }
