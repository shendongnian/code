    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                SomeType s = null;
                //s = new SomeType();
                // uncomment me to try it with an instance
                s.SomeMethodSafe();
                Console.WriteLine("Done");
                Console.ReadLine();
            }
        }
   
        public class SomeType
        {
            public void SomeMethod()
            {
                Console.WriteLine("Success!");
            }
        }
        public static class SampleExtensions
        {
            public static void SomeMethodSafe(this SomeType t)
            {
                if (t != null)
                {
                    t.SomeMethod();
                }
            }
        }
    }
