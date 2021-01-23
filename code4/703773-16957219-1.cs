    Dictionary<string, object> d = new Dictionary<string, object>();
    Dictionary<int, string> d2 = new Dictionary<int, string>();
    List<string> d3 = new List<string>();
    Console.WriteLine(d is System.Collections.IDictionary);
    Console.WriteLine(d2 is System.Collections.IDictionary);
    Console.WriteLine(d3 is System.Collections.IDictionary);
