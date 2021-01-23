    public void DoFunConfigStuff()
    {
        for (var i = 0; i < Config.Count;i++ )
        {
            Console.WriteLine("[{0}]: {1}",Config.Keys[i] ,Config[i]);
        }
    }
