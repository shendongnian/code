    internal class MyFkeyConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(FluentNHibernate.Member property, Type type)
        {
            if(property != null)
                return property.Name + "ID";
            return type.Name + "ID";
        }
    }
