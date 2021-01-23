    namespace Enum
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test test = new Test();
                Console.WriteLine(test.FruitCount);
            }
        }
    
        public class Test
        {
            enum Fruits { Apple, Orange, Peach }
            public int FruitCount
            {
                get
                {
                    return System.Enum.GetNames(typeof(Fruits)).Length;
                }
            }
        }
    }
