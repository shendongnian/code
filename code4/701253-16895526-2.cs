    private static void TestSaving()
    {
        ClsdataSourceCollection collection = new ClsdataSourceCollection();
        for (int i = 0; i < 100; i++)
        {
            collection.Add(new Clsdatasource(true, true, true));
        }
        collection.SaveData(()=> Console.WriteLine("Saved"));
    }
    private static void TestLoading()
    {
        ClsdataSourceCollection collection = new ClsdataSourceCollection();
        collection.LoadData(() => Console.WriteLine("Loaded"));
    }
