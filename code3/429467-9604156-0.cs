    public class Foo
    {
        private static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: Foo <input file> <output file>");
                return 1; // Indicate failure
            }
            string inputFile = args[0];
            string outputFile = args[1];
            // Use inputFile and outputFile...
            return 0; // Indicate success
        }
    }
