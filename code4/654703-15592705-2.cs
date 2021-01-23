    public class NavigationPropertyConfigurationConvention
        : IConfigurationConvention<PropertyInfo, NavigationPropertyConfiguration>
    {
        public void Apply(
            PropertyInfo propertyInfo, Func<NavigationPropertyConfiguration> configuration)
        {
            var foreignKeyProperty = 
                propertyInfo.DeclaringType.GetProperty("Id" + propertyInfo.Name);
            if (foreignKeyProperty != null && configuration().Constraint == null)
            {
                var fkConstraint = new ForeignKeyConstraintConfiguration();
                fkConstraint.AddColumn(foreignKeyProperty);
                configuration().Constraint = fkConstraint;
            }           
        }
    }
