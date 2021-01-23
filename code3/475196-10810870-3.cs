    public class Item : ViewModel
    {
        public String Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private String name;
    
        public ObservableCollection<String> SubItems
        {
            get
            {
                return subItems ?? (subItems = new ObservableCollection<String>());
            }
        }
        private ObservableCollection<String> subItems;
    }
