    namespace Enum
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(FruitCount);
            }
        }
    
        public class Test
        {
            enum Fruits { Apple, Orange, Peach }
            const int FruitCount = System.Enum.GetNames(typeof(Fruits)).Length;
        }
    }
