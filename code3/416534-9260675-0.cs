    long _n;
    int _i;
    long _mod;
    
    long FindModulusParallel(long n, int i)
    {
    	_mod = _n = n;
    	_i = i;
    	
    	var actions = Enumerable.Range(0, Environment.ProcessorCount)
                                .Select<int,Action>(j => Subtract).ToArray();
    	Parallel.Invoke(actions);
    	
    	return _mod;
    }
    
    void Subtract()
    {
    	while (Interlocked.Add(ref _n, -_i) >= 0)
    		Interlocked.Add(ref _mod, -_i);
    }
