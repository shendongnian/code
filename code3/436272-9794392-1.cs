    public class UtcDateTimeConvention : IPropertyConvention, IPropertyConventionAcceptance
    	{
    		public void Apply(IPropertyInstance instance)
    		{
    			instance.CustomType<UtcDateTimeType>();
    		}
    
    		public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
    		{
    			criteria.Expect(x =>
    				x.Property.PropertyType.Equals(typeof(DateTime)) ||
    				x.Property.PropertyType.Equals(typeof(DateTime?)));
    		}
    	}
