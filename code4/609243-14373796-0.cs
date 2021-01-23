    public class ComponentViewModel : ViewModel /* ViewModel is a basic implementation of INotifyPropertyChanged interface */
    {
        public ComponentViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>
            {
                new ItemViewModel { IsActive = true, DateTime = DateTime.Now, Name = "Lemons" },
                new ItemViewModel { IsActive = true, DateTime = DateTime.Now, Name = "Melons" },
                new ItemViewModel { IsActive = true, DateTime = DateTime.Now, Name = "Apples" },
            };
        }
        public ObservableCollection<ItemViewModel> Items { get; private set; }
    }
    public class ItemViewModel : ViewModel
    {
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                if (isActive != value)
                {
                    isActive = value;
                    OnPropertyChanged("IsActive");
                }
            }
        }
        private bool isActive;
        public string Name
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
        private string name;
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;
                    OnPropertyChanged("DateTime");
                }
            }
        }
        private DateTime dateTime;
    }
