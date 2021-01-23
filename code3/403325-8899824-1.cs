    private static string RemoveQuotes(string input) {
        if (input.StartsWith("\"") && input.EndsWith("\"")) {
            return input.Substring(1, input.Length - 2);
        } else {
            return input;
        }
    }
    public static void Main(string[] args) {
      // ...
      Console.WriteLine("Pfad eingeben: ");
      pfad = RemoveQuotes(Console.ReadLine());
      Console.WriteLine("Pfad eingeben: ");
      pfad2 = RemoveQuotes(Console.ReadLine());      
      // ...
   }
