    void Main(string[] args)
    {
        if(args != null && args.Lenght > 0)
        {
            if(File.Exists(args[0]))
            {
                using(StreamReader sr = new StreamReader(args[0]))
                {
                    string line = sr.ReadLine();
                    ........
                }
            }
        }
    }
