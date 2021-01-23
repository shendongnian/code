    class Params
    {
    	public int First {get;set;}
    	public int Second {get;set;}
    }
    
    interface IAverageCounter
    {
    	double Calculate(Params parameters);
    }
    
    class SomeAverage : IAverageCounter
    {
    	public double Calculate(Params parameters)
    	{
    		return (parameters.First + parameters.Second) / 2;
    	}
    }
    
    
    class OtherAverage : IAverageCounter
    {
    	public double Calculate(Params parameters)
    	{
    		return (parameters.Second - parameters.First) / 2
    	}
    }
