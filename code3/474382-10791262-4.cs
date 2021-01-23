    public interface IUnitOfMeasure<TThis>
    	where TThis : IUnitOfMeasure<TThis>
    {
    	TThis ConvertTo(TThis value);
    }
    
    public struct Mass : IUnitOfMeasure<Mass>
    {
        public enum Units
    	{
    		Gram,
    		Kilogram
    	}
    
        private double _value;
    	private Mass.Units _unit;
    	
    	public double Value { get { return _value; } }
    	
    	public Mass.Units Unit { get { return _unit; } }
    	
    	public Mass(double value, Mass.Units unit)
    	{
    		_value = value;
    		_unit = unit;
    	}
    	
    	public Mass ConvertTo(Mass value)
    	{
    		switch(value.Unit)
    		{
    			case Units.Gram:
    				return new Mass(Unit == Units.Gram ? Value : Value/1000, Units.Gram);
    			case Units.Kilogram:
    				return new Mass(Unit == Units.Gram ? Value*1000 : Value, Units.Kilogram);
    			default:
    				throw new NotImplementedException();
    		}
    	}
    	
    	public override string ToString()
    	{
    		return string.Format("{0} {1}", Value, Unit);
    	}
    	
    	public static readonly Mass G = new Mass(0, Units.Gram);
    	public static readonly Mass Kg = new Mass(0, Units.Kilogram);
    }
