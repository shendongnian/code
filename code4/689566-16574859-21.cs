	public interface IDbMapping
	{
		string TableName { get; }
		IEnumerable<string> Keys { get; }
		Dictionary<string, string> Mappings { get; }
		Type EntityType { get; }
		bool AutoGenerateIds { get; }
	}
	public class EmployeeMapping : IDbMapping
	{
		public string TableName { get { return "Employee"; } }
		public IEnumerable<string> Keys { get { return new []{"Employee"};} }
		public Dictionary<string, string> Mappings { get { return null; } } // indicates default mapping based on entity type } }
		public Type EntityType { get { return typeof (Employee); } }
		public bool AutoGenerateIds { get { return true; } }
	}
