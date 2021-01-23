    public class CaseInsensitiveStringConvention : IPropertyConventionAcceptance, IPropertyConvention
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            // More work could be done here to ensure you get nvarchars only
            criteria.Expect(c => c.Property.PropertyType == typeof(string));
        }
        public void Apply(IPropertyInstance instance)
        {
            instance.CustomSqlType("text COLLATE NOCASE");
        }
    }
