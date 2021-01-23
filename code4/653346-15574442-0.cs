    AddItem(string item)
    {
      _mySet.Add(item);
      //Note this does return an IDisposable if you want to cancel the subscription.
      _scheduler.Schedule(
    	TimeSpan.FromSeconds(60),
    	()=>
    	{ 
    		RemoveItem(item);
    		Console.WriteLine("Removed {0}", item);
    	});
    }
