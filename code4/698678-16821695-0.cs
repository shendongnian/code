    private static void GroupPairs(List<Tuple<string, string>> pairs)
    {
        int groupCounter = 0;
    
        while (pairs.Count > 0)
        {
            var onegroup = new HashSet<string>();
            Console.WriteLine("Group {0}", ++groupCounter);
    
            int initialGroupCount;
            do
            {
                var remainder = new List<Tuple<string, string>>();
                initialGroupCount = onegroup.Count;
                foreach (var curr in pairs)
                {
                    if (onegroup.Contains(curr.Item1) ||
                        onegroup.Contains((curr.Item2)) ||
                        onegroup.Count == 0)
                    {
                        Console.WriteLine("{0} {1}", curr.Item1, curr.Item2);
                        onegroup.Add(curr.Item1);
                        onegroup.Add(curr.Item2);
                    }
                    else
                    {
                        remainder.Add(curr);
                    }
                }
                pairs = remainder;
            } while (initialGroupCount < onegroup.Count);
        }
    }
