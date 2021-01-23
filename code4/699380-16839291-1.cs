    using System.IO;
    public FileInfo GetFileInfo(string filename)
    {
        if(filename == null)
            throw new ArgumentNullException("filename");
        FileInfo info = new FileInfo(filename);
        if(!Path.IsPathRooted(filename) && !info.Exists)
        {
            string[] paths = {
                        Environment.CurrentDirectory,
                        AppDomain.CurrentDomain.BaseDirectory,
                        HostingEnvironment.ApplicationPhysicalPath,
                        };
            foreach(var path in paths)
            {
                if(path != null)
                {
                    string file = null;
                    file = Path.Combine(path, filename);
                    if(File.Exists(file))
                    {
                        return new FileInfo(file);
                    }
                }
            }
        }
        throw new FileNotFoundException("Couldn not find the requested file", filename);
    }
