    string[] col1 = { "zero", "one", "two", "three", "four"};
    List<string> col2 = new List<string>{ "zero", "one", "two", "three"};
    static void CheckForDigit(IList collection, string digit)
        {
            Console.Write(collection.Contains(digit));
            Console.Write("----");
            Console.WriteLine(collection.ToString());
        }
    static void Main()
    {
        CheckForDigit(col1, "one");   //True----System.String[]
        CheckForDigit(col2, "one");   //True----System.Collections.Generic.List`1[System.String]
    //Another test:
        CheckForDigit(col1, "four");   //True----System.String[]
        CheckForDigit(col2, "four");   //false----System.Collections.Generic.List`1[System.String]
    }
