    [AttributeUsage(AttributeTargets.Interface|AttributeTargets.Class, Inherited=false)]
    public sealed class ServiceContractAttribute : Attribute
    {
        public bool Session {get;set;}
        ... // More members
    }
