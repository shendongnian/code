    var queue = new TheCheapestPubSubEver();
    	
    var ofString = queue.Register<string>();
    var anotherOfString = queue.Register<string>();
    var ofInt = queue.Register<int>();
    	
    using(ofInt.Subscribe(i => Console.WriteLine("An int! {0}", i)))
    using(ofString.Subscribe(s => Console.WriteLine("A string! {0}", s)))
    using(anotherOfString.Subscribe(s => Console.WriteLine("Another string! {0}", s)))
    {
        queue.Publish("Foo");
        queue.Publish(1);
        Console.ReadLine();
    }
