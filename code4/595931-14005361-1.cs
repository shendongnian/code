    public ObservableCollection<MyObject> MyCollection { get; set; }
    
    public MyObject MySelectedItem { get; set; } // You'll want to use INotifyPropertyChanged magic here
    private void RemoveItemExcecute()
    {
        MyCollection.Remove(MySelectedItem);
    }
