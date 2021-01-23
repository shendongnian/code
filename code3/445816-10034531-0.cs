    static void Main(string[] args)
    {
        var task = Task.Factory.StartNew<int>(GetInt);
    
        var task2 = Task.Factory.StartNew(
            () =>
            {
                return GetInt();
            });
    }
    
    static int GetInt()
    {
        return 64;
    }
