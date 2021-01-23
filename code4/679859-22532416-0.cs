    public class BaseClass<T> where T : BaseClass<T>
        {
            public static string InstanceCreationEditor()
            {
                return typeof(T).Name;
            }    
        }
    
        public class FooClass : BaseClass<FooClass>
        {
            
        }
    
        public class BooClass : BaseClass<BooClass>
        {
            
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var ret = FooClass.InstanceCreationEditor();
                if(ret == typeof(FooClass).Name)
                {
                    Console.WriteLine(true);
                }
                var ret1 = BooClass.InstanceCreationEditor();
                if (ret1 == typeof(BooClass).Name)
                {
                    Console.WriteLine(true);
                }
            }
        }
