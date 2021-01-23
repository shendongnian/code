    public class YourWindowViewModel : INotifyPropertyChanged
                {
                        ObservableCollection<CProject> projectList;
            
            // Properties
            public ObservableCollection<CProject> ProjectList {
              get { return projectList; }
              set {
                projectList = value;
                OnPropertyChanged("ProjectList");
              }
            }
        
            public  YourWindowViewModel ()
                {
                    // fill project list here
                     this.ProjectList = new ObservableCollection<CProject>(client.getProjectList(username, password));
                 }
            }
