     class Program
    {
        static void Main(string[] args)
        {
            List<int[]> c_top=new List<int[]>();
            c_top.Add(new int[3]{ 2, 10, 1});
            c_top.Add(new int[3]{ 7,  8, 1});
            c_top.Add(new int[3]{ 2,  7, 2});
            c_top.Add(new int[3]{ 3,  6, 1});
            c_top.Add(new int[3]{  4,  6, 2});
            var result=c_top.Where(x => x[0] == x[2]).Select(s => s[0]).ToList();
        }
    }
