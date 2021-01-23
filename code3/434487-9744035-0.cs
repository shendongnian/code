    var copy = new ObservableCollection<YourType>(collection)
    foreach(var item in copy)
    {
        if(item.Name == "Fred")
        {
            collection.Remove(item);
        }
    }
