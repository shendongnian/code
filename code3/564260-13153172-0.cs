    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    
    namespace CollectionChangedSpike
    {
        public class ViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<ProjectItem> _projectItems = new ObservableCollection<ProjectItem>();
            public ObservableCollection<ProjectItem> ProjectItems
            {
                get { return _projectItems; }
                set { _projectItems = value; OnPropertyChanged("ProjectItems");}
            }
    
            public ViewModel()
            {
                //Just for debugging
                ProjectItems.CollectionChanged += OnProjectItemsChanged;
            }
    
            private void OnProjectItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                OnPropertyChanged("ProjectItems");
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
    
    
        }
    }
