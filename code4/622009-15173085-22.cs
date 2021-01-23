    public class Dict : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public string SubName { get; set; }
        public bool Selected { get; set; }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Dict> Dictionaries { get; set; }
        public ViewModel()
        {
            Dictionaries = new ObservableCollection<Dict>()
            {
                new Dict()
                    {
                        Name = "English",
                        SubName = "en",
                        Selected = false,
                    },
                    new Dict()
                    {
                        Name = "English-British",
                        SubName = "en-uk",
                        Selected = true
                    },
                    new Dict()
                    {
                        Name = "French",
                        SubName = "fr",
                        Selected = true
                    }
            };
            Dictionaries.CollectionChanged += DictionariesCollectionChanged;
        }
        private void DictionariesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(var dict in e.NewItems.Cast<Dict>())
                        dict.PropertyChanged += DictionaryChanged;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var dict in e.OldItems.Cast<Dict>())
                        dict.PropertyChanged -= DictionaryChanged;
                    break;
            }
        }
        private void DictionaryChanged(object sender, PropertyChangedEventArgs e)
        {
            Dict dictionary = (Dict)sender;
            //handle a change in Dictionary
        }
    }
