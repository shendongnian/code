    ``class Program
        {
            static HashSet<List<int>> SubsetMaker(int[] a, int sum)
            {
                var set = a.ToList<int>();
                HashSet<List<int>> subsets = new HashSet<List<int>>();
                subsets.Add(new List<int>());
                for (int i =0;i<set.Count;i++)
                {
                    //subsets.Add(new List<int>() { set[i]});
                    HashSet<List<int>> newSubsets = new HashSet<List<int>>();
                    for (int j = 0; j < subsets.Count; j++)
                    {
                       var newSubset = new List<int>();
                       foreach (var temp in subsets.ElementAt(j))
                       {
                          newSubset.Add(temp);
                         
    
                        }
                        newSubset.Add(set[i]);
                        newSubsets.Add(newSubset);
                        
                    }
                    Console.WriteLine("New Subset");
                    foreach (var t in newSubsets)
                    {
                        var temp = string.Join<int>(",", t);
                        temp = "{" + temp + "}";
                        Console.WriteLine(temp);
                    }
                    Console.ReadLine();
    
                    subsets.UnionWith(newSubsets);
                }
                //subsets.Add(new List<int>() { set[set.Count - 1] });
                //subsets=subsets.;
                return subsets;
    
            }
            static void Main(string[] args)
            {
                int[] b = new int[] { 1,2,3 };
                int suma = 6;
                var test = SubsetMaker(b, suma);
                Console.WriteLine("Printing final set...");
                foreach (var t in test)
                {
                    var temp = string.Join<int>(",", t);
                    temp = "{" + temp + "}";
                    Console.WriteLine(temp);
                }
                Console.ReadLine();
    
            }
        }``
