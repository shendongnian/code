    public class HelpMeAttribute : Attribute
    {
        public Type Type { get; set; }
    }
    ...
    [HelpMe(Type = typeof(MyClass2)]
