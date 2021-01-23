    class Program
    {
        static void Main(string[] args)
        {
            RelativePath relative = @"Relative\Path\One";
    
            Console.WriteLine(relative.Path);
            string path = relative;
            Console.WriteLine(path);
    
            Console.ReadLine();
        }
    }
    
    public class RelativePath
    {
    
        public static string RootPath()
        {
            return @"C:\MyRootPath\";
        }
    
        public string Path
        {
            get;
            protected set;
        }
    
        public RelativePath(string relativePath)
        {
            this.Path = relativePath;
        }
    
        public static implicit operator RelativePath(string path)
        {
            return new RelativePath(path);
        }
    
        public static implicit operator string(RelativePath relativePath)
        {
            return System.IO.Path.Combine(RootPath(), relativePath.Path);
        }
    
    }
