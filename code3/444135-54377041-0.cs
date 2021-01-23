	public class NoInsertUpdateConvention : AttributePropertyConvention<NoInsertUpdateAttribute>
	{
		protected override void Apply(NoInsertUpdateAttribute attribute, IPropertyInstance instance)
		{
			instance.Not.Insert();
			instance.Not.Update();
		}
	}
