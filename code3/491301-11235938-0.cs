    public Dictionary<int, int> dictionary = new Dictionary<int, int>();
    
    public void Increment()
    {
    	int newValue = dictionary[0] + 1;
    	//meanwhile, right now in another thread: dictionary = new Dictionary<int, int>();
    	dictionary[0] = newValue; //at this point, "dictionary" is actually pointing to a whole new instance
    }
