    [KnownType("DerivedTypes")]
    [DataContract]
    public abstract class TaskBase : EntityBase
    {
        // other class members here
    
        private static Type[] DerivedTypes()
        {
            return typeof(TaskBase).GetDerivedTypes(Assembly.GetExecutingAssembly()).ToArray();
        }
    }
