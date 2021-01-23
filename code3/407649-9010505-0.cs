    class BaseClass
    {
        public int i { get; set; }
        public BaseClass Clone(BaseClass b)
        {
            BaseClass clone = new BaseClass();
            clone.i = b.i;
            return clone;
        }
    }
    class SubClass : BaseClass
    {
        public int j { get; set; }
        public void foo() { Console.WriteLine("in SubClass with value of i = {0}", i.ToString()); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass b1 = new BaseClass() { i = 17 };
            BaseClass b2 = new BaseClass() { i = 35 };
            SubClass sub1 = CloneAndUpcast<SubClass>(b1);
            SubClass sub2 = CloneAndUpcast<SubClass>(b2);
            sub1.foo();
            sub2.foo();
        }
        static T CloneAndUpcast<T>(BaseClass b) where T : BaseClass, new()
        {
            T clone = new T();
            var members = b.GetType().GetMembers(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i].MemberType== MemberTypes.Property)
                {
                    clone
                        .GetType()
                        .GetProperty(members[i].Name)
                        .SetValue(clone, b.GetType().GetProperty(members[i].Name).GetValue(b, null), null);
                }
            }
            return clone;
        }
    }
