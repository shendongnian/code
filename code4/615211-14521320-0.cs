    class Foo<T> : DynamicObject
    {
        private T _instance;
        public Foo(T instance)
        {
            _instance = instance;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var member = typeof(T).GetProperty(binder.Name);
            if (_instance != null &&
                member.CanWrite &&
                value.GetType() == member.PropertyType)
            {
                member.SetValue(_instance, value, null);
                return true;
            }
            return false;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var member = typeof(T).GetProperty(binder.Name);
            if (_instance != null &&
                member.CanRead)
            {
                result = member.GetValue(_instance, null);
                return true;
            }
            result = null;
            return false;
        }
    }
    class Bar
    {
        public int SomeProperty { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var bar = new Bar();
            dynamic thing = new Foo<Bar>(bar);
            thing.SomeProperty = 42;
            Console.WriteLine(thing.SomeProperty);
            Console.ReadLine();
        }
    }
