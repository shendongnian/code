    var col = new ObservableCollection<string>();
    col.Add("hello");
    col.Add("world");
    col.CollectionChanged += (sender, e) => Console.WriteLine(e.OldStartingIndex);
    col.RemoveAt(1);
    col.RemoveAt(0);
