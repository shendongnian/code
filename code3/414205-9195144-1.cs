    public class Hack : IEnumerable {
        public int LuckyNumber { get; set; }
        public double Total { get; private set; }
        public void Add(string message, int operand1, double operand2, double operand3) {
            Console.WriteLine(message);
            this.Total += operand1 * operand2 - operand3;
        }
        public IEnumerator GetEnumerator() { throw new NotImplementedException(); }
    }
    
    class Program {
        static void Main(string[] args) {
            Hack h1 = new Hack() {
                { "Hello", 1, 3, 2},
                { "World", 2, 7, 2.9}
            };
            Console.WriteLine(h1.Total);
            Hack h2 = new Hack() { LuckyNumber = 42 };
            Console.WriteLine(h2.LuckyNumber);
        }
    }
