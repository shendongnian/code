    class Program
    {
        private static int CompareWithNumbers(FileInfo x, FileInfo y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're 
                    // equal.  
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y 
                    // is greater.  
                    return -1;
                }
            }
            else
            {
                // If x is not null... 
                // 
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // replace all charecters with numbers 
                    Regex r = new Regex("[^0-9]");
                    int xCopy = int.Parse(r.Replace(x.Name.ToString(),""));
                    int yCopy = int.Parse(r.Replace(y.Name.ToString(), ""));
                    int retval = xCopy<yCopy?-1:1;
                    return retval;
                }
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo("d:\\temp");
            List<FileInfo> finfos = new List<FileInfo>();
            finfos.AddRange(di.GetFiles("*"));
            finfos.Sort(CompareWithNumbers);
            //you can do what ever you want
        }
    }
