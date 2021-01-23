    using System.Collections.ObjectModel;
    using Microsoft.Practices.Prism.ViewModel;
    
    namespace ListViewCombo
    {
        class MainViewModel : NotificationObject
        {
            public MainViewModel()
            {
                for (int i = 0; i < 3; i++)
                {
                    ObservableCollection<Task> Source = new ObservableCollection<Task>();
                    for (int j = 0; j < 5; j++)
                    {
                        Source.Add(new Task { ID = i, Name = "Name_" + i, Duration = (i + 2) * 6 + (3 * j) });
                    }
                    MyItems.Add(new TfsTask { ID = i, Items = Source });
                }                        
            }
           
            private ObservableCollection<TfsTask> _myItems = new ObservableCollection<TfsTask>();
            public ObservableCollection<TfsTask> MyItems
            {
                get { return _myItems; }
                set { _myItems = value; RaisePropertyChanged(() => MyItems); }
            }    
        }
    
        public class Task
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Duration { get; set; }
        }
    
        public class TfsTask
        {
            public int ID { get; set; }
            public ObservableCollection<Task> Items { get; set; }
            public Task SelectedItem { get; set; }
        }
    }
