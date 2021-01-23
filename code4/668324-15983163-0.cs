	public class ManyToManyLinkedTableConvention : IHasManyToManyConvention
	{
		public void Apply(IManyToManyCollectionInstance instance)
		{
			var naming = new NamingStrategy();
			string firstName;
			string secondName;
			if (StringComparer.InvariantCultureIgnoreCase.Compare(instance.EntityType.Name, instance.OtherSide.EntityType.Name) >
			    0)
			{
				firstName = instance.EntityType.Name;
				secondName = instance.OtherSide.EntityType.Name;
			}
			else
			{
				secondName = instance.EntityType.Name;
				firstName = instance.OtherSide.EntityType.Name;
				instance.Not.Inverse();
			}
			instance.Table(naming.Quote(
				string.Format(
					"{0}To{1}",
					Inflector.Inflector.Pluralize(firstName),
					Inflector.Inflector.Pluralize(secondName))));
		}
	}
