    // pretend your service returns this
    class MyItem { public string Name { get; set; } }
    
    // this is a property in your view model, bind your gridview to it
    public ObservableCollection<MyItem> Items { get; set; }
    // call this to load, it will continue to populate the UI until it is done
    async System.Threading.Tasks.Task LoadAsync()
    {
        var _Results = await GetItemsAsync();
        foreach (var item in _Results.OrderBy(x => x.Name))
            this.Items.Add(item);
    }
