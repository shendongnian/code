    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IGroupRepository _repository;
        private readonly IGroupViewModelFactory _groupViewModelFactory;
        public MainWindowViewModel(IGroupRepository repository, IGroupViewModelFactory groupViewModelFactory)
        {
            _repository = repository;
            _groupViewModelFactory = groupViewModelFactory;
        }
        public ObservableCollection<GroupViewModel> Groups
        {
            get
            {
                var groupVms = new ObservableCollection<GroupViewModel>();
                IEnumerable<Group> groups = _repository.GetAllGroups();
                foreach (Group g in groups)
                {
                    var vm = _groupViewModelFactory.Create(g);
                    groupVms.Add(vm);
                }
                return groupVms;
            }
        }
    }
