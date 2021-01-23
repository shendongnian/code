    static void Main()
        {
            // Use these two StringComparer instances for demonstration.
            StringComparer comparer1 = StringComparer.Ordinal;
            StringComparer comparer2 = StringComparer.OrdinalIgnoreCase;
    
            // First test the results of the Ordinal comparer.
            Console.WriteLine(comparer1.Equals("value-1", "value-1")); // True
            Console.WriteLine(comparer1.Equals("value-1", "VALUE-1")); // False
            Console.WriteLine(comparer1.Compare("a", "b"));
            Console.WriteLine(comparer1.Compare("a", "a"));
            Console.WriteLine(comparer1.Compare("b", "a"));
    
            // Test the results of the OrdinalIgnoreCase comparer.
            Console.WriteLine(comparer2.Equals("value-1", "value-1")); // True
            Console.WriteLine(comparer2.Equals("value-a", "value-b")); // False
            Console.WriteLine(comparer2.Equals("value-1", "VALUE-1")); // True
            Console.WriteLine(comparer2.Compare("a", "B"));
            Console.WriteLine(comparer2.Compare("a", "A"));
            Console.WriteLine(comparer2.Compare("b", "A"));
        }
