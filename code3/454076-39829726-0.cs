    public interface IEngine
	{
		string Name {get;set;}
	}
	
	public class Car
	{
		public IEngine Engine {get;set;}
	}
	
	public class ElectricEngine : IEngine 
	{
		public string Name {get;set;}
		public int batteryPrecentageLeft {get;set;}
	}
	
	public class InternalCombustionEngine : IEngine 
	{
		public string Name {get;set;}
		public int gasLitersLeft  {get;set;}
	}
