    public class User {
        
        public string Name { get; set; }
        private ObservableCollection<Project> _projects = new ObservableCollection<Project>();
        public ObservableCollection<Project> Projects { get { return _projects; } }
        public User() {
            Projects.CollectionChanged += OnProjectCollectionChanged;
        }
        protected void OnProjectCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            var projects = sender as IEnumerable<Project>;
            switch (e.Action) {
                case NotifyCollectionChangedAction.Add:
                    foreach (var project in projects) {
                        if (project.LeadUser != this) {
                            project.LeadUser = this;
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var project in projects) {
                        if (project.LeadUser == this) {
                            project.LeadUser = null;
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }
    }
