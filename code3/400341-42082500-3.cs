	internal interface IWritableTestItem
	{
		ModelItem  Owner { get; set; }
		ModelScope Scope { get; set; }
	}
	public partial class TestItem : IWritableTestItem
	{
		ModelItem IWritableTestItem.Owner
		{
			get => Owner;
			set => Owner = value;
		}
		ModelScope IWritableTestItem.Scope
		{
			get => Scope;
			set => Scope = value;
		}
	}
