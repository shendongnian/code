    public class MainViewModel : BaseViewModel
    {
        public IEnumerable<TechnicianViewModel> AvailableTechnicians { get { return _technicians; } }
        public TechnicianViewModel SelectedTechnician 
        { 
            get { return _selected; } 
            set 
            { 
                _selected = value; 
                RaiseNotifyPropertyChanged("SelectedTechnician");
            } 
        }
        ...
    }
    public class TechnicianViewModel : BaseViewModel
    {
        public IEnumerable<TestViewModel> Tests { get { return _tests; } }
    }
