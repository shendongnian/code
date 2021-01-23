    using System.IO;
    namespace Test
    {
        class Program 
        {
            static void Main(string[] args)
            {
                // try to name your variables in a meaningful way.
                string[] xmlFiles = Directory.GetFiles(@"C:\test", "*.xml");
                string[] jpgFiles = Directory.GetFiles(@"C:\test", "*.jpg");
    
                // File.CreateText creates a new file and returns a stream writer.
                // wrap it in a using statement so you don't have to worry about closing it yourself
                using (var writer = File.CreateText(@"C:\test\logfile_c#.txt"))
                {
                    FileInfo fi;
                    foreach (string name in xmlFiles)
                    {
                        // FileInfo instances will give you access to properties
                        // of the file, including the creation date and time.
                        fi = new FileInfo(name);
                        // Use an overload of WriteLine using a format string.
                        writer.WriteLine("file name: {0}, creation time: {1}", name, fi.CreationTime);
                    }
                    foreach (string name in jpgFiles)
                    {
                        fi = new FileInfo(name);
                        writer.WriteLine("file name: {0}, creation time: {1}", name, fi.CreationTime);
                    }
                }
            }
        }
    }
