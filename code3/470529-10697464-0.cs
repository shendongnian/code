    public interface IPath
    {
        string GetPath();
    }
    public class classA : IPath
    {
        public string GetPath()
        {
            return @"C:\";
        }
    }
    public class classB : IPath
    {
        public string GetPath()
        {
            return @"D:\";
        }
    }
    public class ReadPath<T> where T : IPath, new()
    {
        private IPath iPath;
        public List<T> ReadType()
        {
            iPath = new T();
            iPath.GetPath();
            //return some list of type T
        }
    }
