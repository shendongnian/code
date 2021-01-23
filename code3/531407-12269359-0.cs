    public class ViewModel
    {
        private readonly ObservableCollection<Player>();
        public ViewModel()
        {
            _People = new ObservableCollection<Player>();
        }
        public ObservableCollection<Player> People
        {
            get
            {
                return _People;
            }
        }
        /* rest of class */
    }
