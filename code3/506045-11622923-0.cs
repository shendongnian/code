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
