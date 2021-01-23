    void Main()
    {
        var thingy = new Thingy();
        using(thingy.Status.Subscribe(stat => Console.WriteLine("Status:{0}", stat)))
        {
            Console.WriteLine("Waiting three seconds to Init...");
            Thread.Sleep(3000);
            thingy.Init();
            Console.ReadLine();
        }
    }
