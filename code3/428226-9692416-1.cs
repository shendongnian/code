    public class PrimaryKeyConvention : FluentNHibernate.Conventions.IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {            
            instance.Column(instance.EntityType.Name + "Id");
            instance.GeneratedBy.Custom(typeof(CustomIdGenerator));
        }
    }
    public class CustomIdGenerator : NHibernate.Id.IIdentifierGenerator
    {
        public object Generate(NHibernate.Engine.ISessionImplementor session, object obj)
        {
            return null; //this should be custom implemented
        }
    }
