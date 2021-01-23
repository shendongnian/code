    interface IPresentationService
    {
        bool ShowInDialog(ViewModel viewModel);
    }
    
    class CarViewModel : ViewModel {}
    class MainViewModel : ViewModel
    {
        [Import]
        private IPresentationService presentationService;
    
        private void AddNewCar()
        {
            var car = new CarViewModel();
            if (presentationService.ShowInDialog(car))
            {
                Cars.Add(car);
            }
        }
    
        public MainViewModel()
        {
            Cars = new ObservableCollection<CarViewModel>();
            AddNewCarCommand = new RelayCommand(AddNewCar);
        }
    
        public ObservableCollection<CarViewModel> Cars { get; private set; }
        public ICommand AddNewCarCommand { get; private set; }
    }
