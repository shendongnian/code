    void Main()
    {
    	var s1 = new Subject<double>();
    	var s2 = new Subject<double>();
    	var s3 = new Subject<double>();
    	var s4 = new Subject<double>();
    
    	var result = (s1.Wrap() + s2) / s3 + (s4.Wrap() * 2.0.Const());
    	using(result.Source.Subscribe(Console.WriteLine))
    	{
    		s1.OnNext(1.0);
    		s2.OnNext(2.0);
    		s3.OnNext(3.0);
    		s4.OnNext(4.0);
    	}
    }
