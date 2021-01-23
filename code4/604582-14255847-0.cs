    public class Program {
        public static void Main(String[] args) {
            Looper(x => x + 1);
            Looper(x => ++x);
            //Looper(x => x++); will not works
            Looper(x => x * 2);
        }
        public static void Looper(Func<int, int> op) {
            for (int i = 1; i < 10; i = op(i)) {
                Console.WriteLine(i);
            }
            Console.WriteLine("----------");
        }
            
    } 
