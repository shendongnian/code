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
                        
                    int retval = x.CreationTime<y.CreationTime?-1:1;
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
