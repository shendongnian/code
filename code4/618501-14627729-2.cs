    abstract class ChainElement
    {
    	ChainElement _next;
    	
    	public ChainElement RegisterNext(ChainElement next)
    	{
    		_next = next;
    		return next;
    	}
    	
    	public double GetBonusRate(int workingDays, int numberOfSales)
    	{
    		if(IsMatched(workingDays, numberOfSales))
    		{
    			return GetBonusValue();
    		}
    		
    		return _next.GetBonusRate(workingDays, numberOfSales);
    	}
    	
    	protected abstract bool IsMatched(int workingDays, int numberOfSales);
    	
    	protected abstract int GetBonusValue();
    }
    
    class PerfectBonusRate : ChainElement
    {
    	protected override bool IsMatched(int workingDays, int numberOfSales)
    	{
    		return numberOfSales > 20;
    	}
    	
    	protected override double GetBonusValue()
    	{
    		return 1.5;
    	}
    }
    
    class GoodBonusRate : ChainElement
    {
    	protected override bool IsMatched(int workingDays, int numberOfSales)
    	{
    		return workingDays >= 20 && numberOfSales > 10;
    	}
    	
    	protected override double GetBonusValue()
    	{
    		return 1.2;
    	}
    }
    
    //and the same for StandartBonusRate, LazyBonusRate...
    
    class NoBonusRate : ChainElement
    {
    	protected override bool IsMatched(int workingDays, int numberOfSales)
    	{
    		return true;
    	}
    	
    	protected override double GetBonusValue()
    	{
    		return 0.0;
    	}
    }
