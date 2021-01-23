    using System.IO;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                // Rename all files in the C:\Temp\ directory.
                Program.RenameFiles(new DirectoryInfo(@"C:\Temp\"));
            }
    
            public static void RenameFiles(DirectoryInfo path)
            {
                // Does the path exist?
                if (path.Exists)
                {
                    // Get all files in the directory.
                    FileInfo[] files = path.GetFiles("*.jpg");
                    foreach (FileInfo file in files)
                    {
                        // Split the filename
                        string[] parts = file.Name.Split('_');
                        // Concatinate the second and fourth part.
                        string newFilename = string.Concat(parts[1], "_", parts[3]);
                        // Combine the original path with the new filename.
                        string newPath = Path.Combine(path.FullName, newFilename);
                        // Move the file.
                        File.Move(file.FullName, newPath);
                    }
                }
            }
        }
    }
