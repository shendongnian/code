	public class Module
	{
		public Module(string name)
		{
			Name = name;
		}
		
		public string Name { get; private set; }
	}
	Module one = new Module("one");
	Module two = new Module("two");
	Module three = new Module("three");
	Dictionary<string, List<Module>> dict = new Dictionary<string, List<Module>>
	{
		{"cow", new List<Module> { one, two }},
		{"chicken", new List<Module> { one }},
		{"pig", new List<Module> { two }}
	};
	
	string[] roles = new string[] { "cow", "chicken", "pig" };
		
	var result = roles.SelectMany(r => dict[r]).Distinct();
	
	Console.WriteLine(result);
	
	// { one, two }
