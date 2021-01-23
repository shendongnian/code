	void Main()
	{
		Employee emp = new Employee();
		emp.Id = "1";
		
		const string path = @"C:\Documents and Settings\LeeP\Sample.erl";
		
		emp.Dump();
		
		using(var stream = File.Open(path, FileMode.Create))
		{
			var formatter = new BinaryFormatter();
			formatter.Serialize(stream, emp);
		}
		
		using(var stream = File.Open(path, FileMode.Open))
		{
			var formatter = new BinaryFormatter();
			var sample = (Employee)formatter.Deserialize(stream); 
			
			sample.Dump();
		}
	}
	
    // You need to mark this class as [Serializable]
	[Serializable]
	public class Employee
	{
	    public string Name {get; set;}
	    public string Id{get;set;}
	}
