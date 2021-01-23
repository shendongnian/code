    class MyObject
    {
        public string ApplicationName { get; set; }
        public string ClassName { get; set; }
    }
    ObservableCollection<MyObject> results = new ObservableCollection<MyObject>();
    //Populate some data into results here
    ResultListView.ItemsSource =results;
