    public class TreeNode : ViewModel
    {
        public TreeNode()
        {
            this.children = new ObservableCollection<TreeNode>();
            // the magic goes here
            this.addChildCommand = new RelayCommand(obj => AddNewChild());
        }
        private void AddNewChild()
        {
            // create new child instance
            var child = new TreeNode 
            { 
                Name = "This is a new child node.",
                IsSelected = true // new child should be selected
            };
            // add it to collection
            children.Add(child);
            // expand this node, we want to look at the new child node
            IsExpanded = true;
        }
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
        public Boolean IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
        private Boolean isSelected;
        public Boolean IsExpanded
        {
            get { return isExpanded; }
            set
            {
                if (isExpanded != value)
                {
                    isExpanded = value;
                    OnPropertyChanged("IsExpanded");
                }
            }
        }
        private Boolean isExpanded;
        public ObservableCollection<TreeNode> Children
        {
            get { return children; } 
        }
        private ObservableCollection<TreeNode> children;
        public ICommand AddChildCommand
        {
            get { return addChildCommand; }
        }
        private RelayCommand addChildCommand;
    }
