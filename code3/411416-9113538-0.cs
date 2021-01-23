    public class MainViewModel : INotifyPropertyChanged
    {
        // These should be expanded into full properties with get/set methods
        // and the set method should raise the PropertyChanged event
        public ObservableCollection<ITabViewModel> TabViewModels { get; set; }
        public ITabViewModel SelectedTabIndex { get; set; }
        public ICommand ChangeTabCommand { get; set; }
    
        public MainViewModel()
        {
            TabViewModels = new ObservableCollection<ITabViewModel>();
            TabViewModels.Add(new ConfigurationTabViewModel());
            TabViewModels.Add(new ClassificationTabViewModel());
    
            SelectedTabIndex = 0;
    
            ChangeTabCommand = new RelayCommand<int>(ChangeTabIndex);
        }
    
        void ChangeTabIndex(int tabIndex)
        {
            if (tabIndex >= 0 && tabIndex < TabViewModels.Count)
                SelectedTabIndex = tabIndex;
        }
    
        // Also implement INotifyPropertyChanged
    }
