    private int _result = 0;
    private static Random _rand = new Random();
    public int twist(int min, int max)
    {
        int y = _rand.Next(min, max);
	
	    _result += y;
	
	    System.Diagnostics.Debug.WriteLine(_result);
	    return _result;
    }
