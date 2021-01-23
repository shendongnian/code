    public class MainViewModel : ViewModelBase
    {
        private MyEntities context;
    
        public ICollectionView Collection { get; private set; }
    
        private string searchString = "";
        public string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value;
                Collection.Refresh();
            }
        }
    
        public MainViewModel()
        {
            context = new MyEntities(new Uri("http://localhost:3780/Live.svc"));
    
            Collection = new ListCollectionView(context.Clients.ToList());
    
            Collection.Filter = (o) => (o as Client).FullName.ToString().StartsWith(SearchString);
        }
    }
