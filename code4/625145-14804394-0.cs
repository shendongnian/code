    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(IRepository<Parent> parentRepo, IViewModelFactory factory)
        {
            // you might want to set this up as a fancy async method
            // because.. it looks better and it's easier to read
            Task.Factory
                .StartNew(() => parentRepo.GetAll())
                .ContinueWith(t =>
                {
                    // Do error checking and all that boring stuff
                    ParentViewModels =
                        new ObservableCollection<ParentViewModel>(
                            t.Result.Select(p => factory.Create<ParentViewModel>(p)));
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private ObservableCollection<ParentViewModel> _parentViewModels;
        public ObservableCollection<ParentViewModel> ParentViewModels
        {
            get
            {
                return _parentViewModels;
            }
            set
            {
                _parentViewModels = value;
                RaisePropertyChanged("ParentViewModels");
            }
        }
        // INotifyPropertyChanged implementation goes here
    }
    // Super secret sauce viewmodelfactory and repository implementations go here
