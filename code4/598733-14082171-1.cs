    public class MainWindowViewModel
    {
        Private ObservableCollection<ViewModel> _NameViewModels;
    
        Public Void MainWindowViewModel()
        {
            //Lets pretend we have a service that returns a list of models
            var nameModels = Service.Request();
            foreach(Model model in nameModels)
            {
                ViewModel viewmodel = new NameViewModel(model);
                NameViewModel.Add(viewmodel);
            }
        }
    
        Public ObservableCollection<ViewModel> NameViewModels
        {
            get
            {
                return _NameViewModels;
            }
        }
    }
