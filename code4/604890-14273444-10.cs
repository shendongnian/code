    interface IFile
    {
        bool Exists(string name);
        // etc...
    }
    public class FileWrapper : IFile
    {
        public bool Exists(string name)
        {
            return File.Exists(name);
        }
    }
