    public class YourViewModel
        {
            private readonly YourModel model;
            private ObservableCollection<string> foldersToScan = new ObservableCollection<string>();
            public ObservableCollection<string> FoldersToScan
            {
                get { return this.foldersToScan; }
            }
    
            public YourViewModel(YourModel model)
            {
                this.model = model;
                this.model.OnItemAdded += item => this.foldersToScan.Add(item);
            }
    
            public void AddFolder(string addFolder) //gets called from view
            {
                this.model.AddFolder(addFolder); //could be ICommand using Command Pattern
            }
        }
    
        public class YourModel
        {
            private readonly List<string> foldersToScan;
            public IEnumerable<string>  FoldersToScan
            {
                get { return this.foldersToScan; }
            }
    
    
            public event Action<string> OnItemAdded; 
            public YourModel()
            {
                this.foldersToScan = new List<string>();
            }
            public void AddFolder(string folder)
            {
                this.foldersToScan.Add(folder);
                this.RaiseItemAdded(folder);
            }
    
            void RaiseItemAdded(string folder)
            {
                Action<string> handler = OnItemAdded;
                if (handler != null) handler(folder);
            }
        }
