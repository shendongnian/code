    class MyCustomTimer : INotifyPropertyChanged
    {
        string title { get; set; }
        DispatcherTimer timer { get; set; }
        ...
    }
