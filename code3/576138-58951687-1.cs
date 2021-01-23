    var list = new List<KeyValuePair<string, int>>();
    list.Add(new KeyValuePair<string, int>("Cat", 1));
    list.Add(new KeyValuePair<string, int>("Dog", 2));
    list.Add(new KeyValuePair<string, int>("Rabbit", 4));
    	
    int removalStatus = list.RemoveAll(x => x.Key == "Rabbit");
    	
    if (removalStatus == 1)
    {
    	list.Add(new KeyValuePair<string, int>("Rabbit", 5));
    }
