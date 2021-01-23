    static Random random = new Random();
    public static void Main(string[] args)
    {
        var list = new List<int>(Enumerable.Range(1,200));
        while(list.Count>0)
        {
            var item = list[random.Next(0,list.Count)];
            list.Remove(item);
            // Do something with 'item'
        }
    }
