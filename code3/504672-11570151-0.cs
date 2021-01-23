    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 1)
                CreateData(args[0], int.Parse(args[1]));
        }
        public static void CreateData(string s, int i)
        {
            File.WriteAllText(@"C:\data.txt", 
                  string.Format("This is some data:  s = {0}  i = {1}", s, i)); 
        }
    }
