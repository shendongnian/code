    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inheritable = false)]
    public class EnumResourceKeyAttribute : Attribute
    {
     public string ResourceKey { get; set; }
    }
