    public class NodeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<NodeViewModel> _children;
        public ObservableCollection<NodeViewModel> Children { get { return _children; } set { _children = value; OnPropertyChanged("Children"); } }
        private string _id;
        public string Id { get { return _id; } set { _id = value; OnPropertyChanged("ID"); } }
        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("ID"); } }
        private string _description;
        public string Description { get { return _description; } set { _description = value; OnPropertyChanged("Description"); } }
        private bool _isExpanded;
        public bool IsExpanded { get { return _isExpanded; } set { _isExpanded = value; OnPropertyChanged("IsExpanded"); } }
        private bool _isSelected;
        public bool IsSelected { get { return _isSelected; } set { _isSelected = value; OnPropertyChanged("IsSelected"); } }
        public bool HasChildren  // perhaps this can be replaced by HasItems in TemplatedParent?
        {
            get
            {
                if (Children != null)
                {
                    Children.Any();
                }
                return false;
            }
        }
        private static bool _setData = true; // hack for example data
        public NodeViewModel()
        {
            if (_setData)
            {
                _setData = false;
                SetExampleData();
            }
        }
        public void SetExampleData()
        {
            Children = new ObservableCollection<NodeViewModel>()
            {
                new NodeViewModel() { Name = "1", Description = "One"    },
                new NodeViewModel() { Name = "2", Description = "Two"    },
                new NodeViewModel() { Name = "3", Description = "Three"  },
                new NodeViewModel() { Name = "4", Description = "Four"   },
                new NodeViewModel() { Name = "5", Description = "Five"   },
                new NodeViewModel() { Name = "6", Description = "Six"    },
                new NodeViewModel() { Name = "7", Description = "Seven"  },
                new NodeViewModel() { Name = "8", Description = "Eight"  }
            };
            Children[0].Children = new ObservableCollection<NodeViewModel>() 
            {  
                new NodeViewModel() { Name = "1.1", Description="One.One" },
                new NodeViewModel() { Name = "1.2", Description="One.Two" },
                new NodeViewModel() { Name = "1.3", Description="One.Three" }
            };
            Children[0].Children[0].Children = new ObservableCollection<NodeViewModel>() 
            {  
                new NodeViewModel() { Name = "1.1.1", Description="One.One.One" },
                new NodeViewModel() { Name = "1.1.2", Description="One.One.Two" },
            };
            Children[1].Children = new ObservableCollection<NodeViewModel>() 
            {  
                new NodeViewModel() { Name = "2.1", Description="Two.One" },
                new NodeViewModel() { Name = "2.2", Description="Two.Two" },
            };
        }
    }
