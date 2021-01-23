    const int SearchedValue = 296;
    static List<LinkedList<int>> lists;
    static Stack<int> indexes = new Stack<int>();
    private static void Check(int sum, int listIndex)
    {
        if (listIndex == lists.Count)
        {
            if (sum == SearchedValue)
            {
                Console.WriteLine("Found: " + String.Join(", ",
                    indexes.Reverse().Select(i => i + 1).ToArray()));
            }
        }
        else
        {
            int i = 0;
            foreach (var value in lists[listIndex])
            {
                indexes.Push(i++);
                Check(sum + value, listIndex + 1);
                indexes.Pop();
            }
        }
    }
    public static void Main()
    {
        var list1 = new LinkedList<int>();
        list1.AddLast(1);
        list1.AddLast(34);
        list1.AddLast(91);
        var list2 = new LinkedList<int>();
        list2.AddLast(6);
        list2.AddLast(5);
        list2.AddLast(94);
        list2.AddLast(43);
        list2.AddLast(245);
        list2.AddLast(467);
        var list3 = new LinkedList<int>();
        list3.AddLast(98);
        list3.AddLast(39);
        var list4 = new LinkedList<int>();
        list4.AddLast(11);
        
        lists = new List<LinkedList<int>>() { list1, list2, list3, list4 };
        
        Check(0, 0);
    }
