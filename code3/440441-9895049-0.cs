    void Main()
    {
    	TimeSpan elapsed;
    	string result;
    	
        elapsed = TheLINQWay(buildString(1000000), out result);
        Console.WriteLine("LINQ way: {0}", elapsed);
	
        elapsed = TheRegExWay(buildString(1000000), out result);
        Console.WriteLine("RegEx way: {0}", elapsed);
    }
    
    TimeSpan TheRegExWay(string s, out string result)
    {
    	Stopwatch stopw = new Stopwatch();
    	
    	stopw.Start();
    	result = Regex.Replace(s, @"\P{L}", string.Empty);
    	stopw.Stop();
    	
    	return stopw.Elapsed;
    }
    
    TimeSpan TheLINQWay(string s, out string result)
    {
    	Stopwatch stopw = new Stopwatch();
    	
    	stopw.Start();
    	string temp = "";
    	s.Where(c => char.IsLetter(c)).Select(c => temp += c);
    	result = temp;
    	stopw.Stop();
    	
    	return stopw.Elapsed;
    }
    
    string buildString(int len)
    {
    	byte[] buffer = new byte[len];
    	Random r = new Random((int)DateTime.Now.Ticks);
    	
    	for(int i = 0; i < len; i++)
    		buffer[i] = (byte)r.Next(256);
    		
    	return Encoding.ASCII.GetString(buffer);
    }
