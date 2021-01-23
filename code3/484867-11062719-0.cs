    class ComboBoxSampleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public CategoryList List { get; set; }
        public ComboBoxSampleViewModel()
        {
            this.List = new CategoryList();
            NodeCategory = List.Selected;
        }
        private ComboBoxSampleItemViewModel nodeCategory;
        public ComboBoxSampleItemViewModel NodeCategory
        {
            get
            {
                return nodeCategory;
            }
            set
            {
                nodeCategory = value;
                NotifyPropertyChanged("NodeCategory");
            }
        }
        internal void SelectCategory(string p)
        {
            this.NodeCategory = this.List.FindByName(p);
        }
    }
