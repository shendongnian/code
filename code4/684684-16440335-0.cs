    using System;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                Group group = new Group();
                SubGroup subGroup = group.MakeSubgroup(42);
                Console.WriteLine(subGroup.Value);
            }
        }
        public sealed class Group
        {
            public SubGroup MakeSubgroup(int value)
            {
                return _subgroupFactory(value);
            }
            static Func<int, SubGroup> getSubgroupFactory()
            {
                var method = (typeof(SubGroup)).GetMethod("getSubgroupFactory", BindingFlags.NonPublic | BindingFlags.Static);
                return (Func<int, SubGroup>) method.Invoke(null, null);
            }
            static readonly Func<int, SubGroup> _subgroupFactory = getSubgroupFactory();
        }
        public sealed class SubGroup
        {
            private SubGroup(int value)
            {
                this.value = value;
            }
            public int Value
            {
                get
                {
                    return value;
                }
            }
            static Func<int, SubGroup> getSubgroupFactory()
            {
                return param => new SubGroup(param);
            }
            readonly int value;
        }
    }
