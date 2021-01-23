    public static IEnumerable<List<int>> getCpower(List<int> list)
    {
        for (int i = 0; i < (1 << list.Count); i++)
        { 
            var sublist = new List<int>();
            for (int j = 0; j < list.Count; j++)
            {   if ((i & (1 << j)) != 0)
                {   
                    sublist.Add(list[j]); 
                }
            }
            yield return sublist;
        }
    }
