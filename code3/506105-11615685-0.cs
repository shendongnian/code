    Task<List<MyClass>> task = Task.Factory.StartNew(() => GetData());
    App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, 
        new Action(delegate() 
        {
            MyObservableCollection.AddRange(task.Result);
        }));
