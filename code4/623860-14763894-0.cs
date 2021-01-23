    class ViewModel : INotifyPropertyChanged
    {
        // Set up our collection to be read from the View
        public ObservableCollection<String> Collection { get; private set; }
        // This collection will maintain the selected items
        public ObservableCollection<String> SelectedItems { get; private set; }
        public ViewModel()
        {
            // Instantiate
            this.Collection = new ObservableCollection<String>();
            this.SelectedItems = new ObservableCollection<String>();
            // Now let's monitor when this.SelectdItems changes
            this.SelectedItems.CollectionChanged += SelectedItems_CollectionChanged;
            // Fill our collection with some strings (1 to 10).
            // (1) Generate the numbers 1 - 10
            // (2) Convert each number to a string
            // (3) Cast into a list so we can use foreach 
            // (4) Add each item to the collection.
            Enumerable.Range(1, 10)
                .Select(number => number.ToString())   
                .ToList()                              
                .ForEach(this.Collection.Add);
            // Remember! Never reset the ObservableCollection.
            // That is, never say this.Collection = new... (or you'll break the binding).
            // instead use this.Collection.Clear(), and then add the items you want to add
        }
        void SelectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (String str in this.SelectedItems)
                    System.Diagnostics.Debug.WriteLine("New item added {0}", str);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
