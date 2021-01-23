    [System.AttributeUsage(AttributeTargets.Class)]
    public class UserInterfaceIDAttribute : Attribute
    {
        public Guid ID { get; set; }
    }
