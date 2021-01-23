    async void SomeMethod()
    {
    
        Task<List<MyClass>> task = Task.Factory.StartNew(() => GetData());
        MyObservableCollection.AddRange(await task);
    }
