    namespace ConsoleApplication13
    {
        using NewEnumName = ConsoleApplication13.SameName;
    
        internal enum SameName { Value }
    
        internal class Tester
        {
            private void Method1()
            {
                SameName SameName;
                SameName test = SameName.Value;
            }
    
            private void Method2()
            {
                string SameName;
                SameName test = NewEnumName.Value;
            }
        }
    
        public class Program
        {
            private static void Main(string[] args)
            {
                Console.ReadKey();
            }
        }
    }
