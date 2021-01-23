    public class SimpleAssemblyLoader : MarshalByRefObject
    {
        public void Load(string path)
        {
            ValidatePath(path);
            Assembly.Load(path);
        }
        public void LoadFrom(string path)
        {
            ValidatePath(path);
            Assembly.LoadFrom(path);
        }
        private void ValidatePath(string path)
        {
            if (path == null) throw new ArgumentNullException("path");
            if (!System.IO.File.Exists(path))
                throw new ArgumentException(String.Format("path \"{0}\" does not exist", path));
        }
    }
