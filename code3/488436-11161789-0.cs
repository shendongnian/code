    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dataTypes = new Dictionary<string, Type>
                {
                    {"type1", typeof (Type1Object)},
                    {"type2", typeof (Type2Object)},
                    {"type3", typeof (Type3Object)}
                };
                Func<string, CommonBaseClass> GetGenericObject = t =>
                {
                    return (CommonBaseClass)Activator.CreateInstance(dataTypes[t]);
                };
                var myGenericObject = GetGenericObject("type1");
            }
        }
        public class CommonBaseClass { }
        public class Type1Object : CommonBaseClass { }
        public class Type2Object : CommonBaseClass { }
        public class Type3Object : CommonBaseClass { }
    }
