    public class AuditAttribute : Attribute
    {
        public AuditAttribute(Type t)
        {
            this.Type = t;
        }
    
        public  Type Type { get; set; }
        public void DoSomething()
        {
            //type is not Entity
            if (!typeof(Entity).IsAssignableFrom(Type))
                throw new Exception();
            int _id;
            IRepository myRepository = new Repository();
            MethodInfo loadByIdMethod =  myRepository.GetType().GetMethod("LoadById");
            MethodInfo methodWithTypeArgument = loadByIdMethod.MakeGenericMethod(this.Type);
            Entity myEntity = (Entity)methodWithTypeArgument.Invoke(myRepository, new object[] { _id });
        }
    }
