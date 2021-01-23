    backgroundWorker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs args)
    {
        ViewModel.SomeList = DeepClone<List<SomeObject>>(ViewModel.TempList);
    };
    
    backgroundWorker.ProgressChanged += delegate(object s, ProgressChangedEventArgs args)
    {
        var item = DeepClone<SomeObject>((SomeObject)args.UserState);
    
        ViewModel.TempList.Add(item);
    };
    
    public static T DeepClone<T>(T obj)
    {
        using (var ms = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
    
            return (T)formatter.Deserialize(ms);
        }
    }
