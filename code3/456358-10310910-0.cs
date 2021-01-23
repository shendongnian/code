       public class Category : INotifyPropertyChanged
    {
        private string _Name;
        private string _Description;
        public virtual int Id { get; set; }
        public virtual string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name == value)
                    return;
                _Name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public virtual string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (_Description == value)
                    return;
                _Description = value;
                NotifyPropertyChanged("Description");
            }
        }
        public virtual Unit Unit { get; set; }
        public virtual List<Category> ChildCategories { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual bool IsMainCategory { get; set; }
        public Category()
        {
            ChildCategories = new List<Category>();
        }
        public virtual void AddChild(Category child)
        {
            ChildCategories.Add(child);
            child.ParentCategory = this;
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
