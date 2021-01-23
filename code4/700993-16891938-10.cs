    public class MainViewModel
    {
        public ObservableCollection<ResourceViewModel> Resources { get; private set; }
        public MainViewModel()
        {
            Resources = new ObservableCollection<ResourceViewModel> {new ResourceViewModel(), new ResourceViewModel(), new ResourceViewModel()};
        }
    }
    public class ResourceViewModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public ObservableCollection<string> Strings { get; private set; }
        public ResourceViewModel()
        {
            Name = "Resource";
            Strings = new ObservableCollection<string> {"s1", "s2", "s3"};
        }
    }
