    public class MainViewModel: PropertyChangedBase
        {
            private ObservableCollection<Section> _sections;
            public ObservableCollection<Section> Sections
            {
                get { return _sections ?? (_sections = new ObservableCollection<Section>()); }
            }
    
            private Section _selectedSection;
            public Section SelectedSection
            {
                get { return _selectedSection; }
                set
                {
                    _selectedSection = value;
                    OnPropertyChanged("SelectedSection");
                }
            }
        }
