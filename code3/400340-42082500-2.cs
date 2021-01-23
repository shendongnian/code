	public interface ITestItem
	{
		ModelItem  Owner { get; }
		ModelScope Scope { get; }
	}
	public partial class TestItem : ITestItem
	{
        // These implicitly handle ITestItem since the getters are public
		public ModelItem  Owner { get; internal set; }
		public ModelScope Scope { get; internal set; }
	}
