    [AttributeUsage(AttributeTargets.All, Inherited = true)]
    class InheritedAttribute : Attribute
    {}
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    class NotInheritedAttribute : Attribute
    {}
    abstract class Base
    {
        [Inherited, NotInherited]
        public abstract void M();
    }
    class Derived : Base
    {
        public override void M()
        {}
    }
    …
    foreach (var type in new[] { typeof(Base), typeof(Derived) })
    {
        var method = type.GetMethod("M");
        foreach (var inherit in new[] { true, false })
        {
            var attributes = method.GetCustomAttributes(inherit);
            Console.WriteLine(
                "{0}.{1}, inherit={2}: {3}",
                method.ReflectedType.Name, method.Name, inherit,
                string.Join(", ", attributes.Select(a => a.GetType().Name)));
        }
    }
