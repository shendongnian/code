    List<string> a = new List<string>(new string[] { "a1", "a2" });
    List<string> b = new List<string>(new string[] { "b1", "b2" });
    List<string> c = new List<string>(new string[] { "c1", "c2" });
    
    var result = CartesianProduct(new List<List<string>>(){a,b,c});
    
    foreach (var row in result)
    {
        foreach (var item in row)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    
         public static List<List<T>> CartesianProduct<T>(List<List<T>> sets)
                {              
                    List<List<T>> results = new List<List<T>>();
        
                    int solutions = 1;
                    for (int i = 0; i < sets.Count; i++)
                    {
                        solutions *= sets[i].Count;
                    }
                    for (int i = 0; i < solutions; i++)
                    {
                        int j = 1;
                        List<T> elem = new List<T>();
                        foreach (List<T> set in sets)
                        {
                            elem.Add(set[(i / j) % set.Count]);
                            j *= set.Count;
                        }
                        results.Add(elem);
                    }
                    return results;
                }
