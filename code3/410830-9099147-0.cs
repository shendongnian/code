    private static void EnsureValuesAreCoherent(Dictionary<DateTime, ObservableCollection<Car>> param)
    {
    	List<Car> toMove = new List<Car>();
    	foreach (KeyValuePair<DateTime, ObservableCollection<Car>> pair in param)
    	{
    		List<Car> toRemove = new List<Car>();
    		foreach (Car car in pair.Value)
    		{
    			if (car.Production != pair.Key)
    			{
    				toRemove.Add(car);
    			}
    		}
    
    		foreach (Car car in toRemove)
    		{
    			pair.Value.Remove(car);
    			toMove.Add(car);
    		}
    	}
    
    	foreach (Car car in toMove)
    	{
    		ObservableCollection<Car> currentCollection;
    		if (param.TryGetValue(car.Production, out currentCollection))
    		{
    			currentCollection.Add(car);
    		}
    	}
    }
