    void Main()
    {
        var queue = new TheCheapestPubSubEver();
        
        var ofString = queue.Register<string>();
        var ofInt = queue.Register<int>();
        
        using(ofInt.Subscribe(i => Console.WriteLine("An int! {0}", i)))
        using(ofString.Subscribe(s => Console.WriteLine("A string! {0}", s)))
        {
            queue.Publish("Foo");
            queue.Publish(1);
            Console.ReadLine();
        }
    }
