    public class TestApp {
        public static void Main() {
            for (int i = 0; i < 20; i++) {
                IEnumerable<int> sequence = GetRandomSequence();
                Console.WriteLine(sequence.TryGetCount() ?? double.PositiveInfinity);
            }
            Console.ReadLine();
        }
        static Random _rng = new Random();
        //Randomly generates an finite or infinite sequence
        public static IEnumerable<int> GetRandomSequence() {
            int random = _rng.Next(5) * 10;
            if (random == 0) {
                return Sequences.GetFibonacciSequence();
            } else {
                return Sequences.GetIntegerRange(0, random);
            }
        }
    }
