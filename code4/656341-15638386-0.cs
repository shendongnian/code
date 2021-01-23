    public static void Main (string[] args)
    {
        Console.Write ("Console Test ");
        Console.WriteLine (version);
        Console.Write (precursor);
        string start = Console.ReadLine ();
        string input = null;
        if (start == "start") {
            while (true) {
                Console.WriteLine ("Started");
                Console.Write (precursor);
                input = Console.ReadLine ();
            }
        } else {
            Environment.Exit (0);
        }
        if (input != null || !input.equals("0")) {
            //Code
        } else {
            Console.WriteLine("Error: Input null");
        }
    }
