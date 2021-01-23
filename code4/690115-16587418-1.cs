    public void Main()
    {
        var clientHeartbeats = new Subject<int>();
	
        var timeToHold = TimeSpan.FromSeconds(5);
	
        var expiredClients = clientHeartbeats
            .Synchronize()
            .GroupBy(key => key)
            .SelectMany(grp => grp.Throttle(timeToHold).Take(1));
        var subscription = expiredClients.Subscribe(
            // in here put your disconnect action
            i => Console.WriteLine("Disconnect Client: " + i));
		
        while(true)
        {
            var num = Console.ReadLine();
            if (num == "q")
            {
                break;
            }
	   // call OnNext with the client id each time they send hello
            clientHeartbeats.OnNext(int.Parse(num));
        }	
        // if you need to tear down you can do this
        subscription.Dispose();
    }
