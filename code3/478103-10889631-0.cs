    class Program
    {
        static string _fpath;
        static void Main(string[] args)
        {
            // ...stuff
            _fpath = args[3];
        }
        static void WriteFile()
        {
            using(var stream = File.Open(_fpath, ...))
            {
                // write to file
            }
        }
    }
