	public class MainWindowViewModel
	{
		private List<Model> _NamesModel;
		private ObservableCollection<ViewModel> _NamesViewModel;
                private IViewModelFactory factory;
		public void MainWindowViewModel(IViewModelFactory factory)
		{
		    //Lets pretend we have a service that returns a list of models
			_NamesModel = Service.Request();
			_NamesViewModel = factory.CreateNamesViewModels(_NamesModel);
		}
		public ObservableCollection<ViewModel> NamesViewModel
		{
			get
			{
				return _NamesViewModel;
			}
		}
	}
