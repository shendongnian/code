    //Viewmodel
    public class WindowViewModel : INotifyPropertyChanged
    {
        private volatile bool _canWork;
        private List<string> _items;
        private ObservableCollection<string> _obervableItems;
        public WindowViewModel()
        {
            //Queue some tasks for adding and modifying the list
            ThreadPool.QueueUserWorkItem(AddItems);
            ThreadPool.QueueUserWorkItem(ModifyItems);
            //Create a background worker to do some work and then we can bind the output to
            //our ObservableList
            var obervableWorker = new BackgroundWorker();
            obervableWorker.DoWork += ObervableWorkerOnDoWork;
            obervableWorker.RunWorkerCompleted += ObervableWorkerOnRunWorkerCompleted;
            
            obervableWorker.RunWorkerAsync();
        }
        private void ObervableWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            var items = ObservableItems as ObservableCollection<string>;
            var workerItems = runWorkerCompletedEventArgs.Result as List<string>;
            foreach (var workerItem in workerItems)
            {
                items.Add(workerItem);
            }
            for (int i = 50; i < 60; i++)
            {
                var item = items.First(x => x == i.ToString());
                items.Remove(item);
            }
        }
        private void ObervableWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            Thread.Sleep(100);
            int count = 0;
            var items = new List<string>();
            while (100 > count++)
            {
                items.Add(count.ToString());
            }
            doWorkEventArgs.Result = items;
        }
        private void ModifyItems(object state)
        {
            while (!_canWork)
            {
                Thread.Sleep(100);
            }
            var items = Items as List<string>;
            for (int i = 50; i < 60; i++)
            {
                items.RemoveAt(i);
            }
        }
        private void AddItems(object state)
        {
            Thread.Sleep(100);
            int count = 0;
            var items = Items as List<string>;
            while (100 > count++)
            {
                items.Add(count.ToString());
            }
            _canWork = true;
        }
        public IEnumerable<string> Items
        {
            get { return _items ?? (_items = new List<string>()); }
            set { _items = new List<string>(value);
                OnPropertyChanged();
            }
        }
        public IEnumerable<string> ObservableItems
        {
            get { return _obervableItems ?? (_obervableItems = new ObservableCollection<string>()); }
            set { _obervableItems = new ObservableCollection<string>(value); OnPropertyChanged();}
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
