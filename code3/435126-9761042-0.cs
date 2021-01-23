    const int SearchedValue = 100;
    static List<LinkedList<int>> lists = new List<LinkedList<int>>();
    static Stack<int> indexes = new Stack<int>();
    public static void Main(string[] args)
    {
        // Init lists...
        Check(0, 0);
    }
    private static void Check(int sum, int listIndex)
    {
        if (listIndex == lists.Count)
        {
            if (sum == SearchedValue)
            {
                Console.WriteLine("Found: " + string.Join(", ", indexes.ToArray()));
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
