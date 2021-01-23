    public class YourViewModel : ViewModelBase
    {
        private YourDeepObjectGraphClass _instance;
        public YourDeepObjectGraphClass Instance
        {
            get { return _yourClass; }
            set
            {
                _yourClass = value;
                OnPropertyChanged("Instance");
            }
        }
        
        public void FlattenGraph()
        {
            foreach (IEnumerable<DeepObjectGraphType> t in Instance.List)
            {
                ((dynamic)Instance).YourDynamicProperty = t.SomeProperty;
            }
        }
    }
