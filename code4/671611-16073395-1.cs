    public class HelpMeAttribute : Attribute
    {
        public Type Type { get; set; }
        ...
        public HelpMeAttribute()
        {
        }
    }
    ...
    [HelpMe(Type = typeof(MyClass2))]
    public class MyClass1
    {
    }
