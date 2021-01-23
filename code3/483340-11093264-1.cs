     public class MainViewModel
     {
         private IViewPersonViewModel _viewModel;
         public MainViewModel(IViewPersonViewModelFactory viewModelFactory)
         {
             _viewModel = viewModelFactory.CreateViewPersonViewModel(parameters..);
         }
     }
