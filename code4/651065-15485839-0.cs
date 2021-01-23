       public static void Main()
            {
                const string TargetPath = @"C:\Users\me\Desktop\FOLDER";
                var dir = new DirectoryInfo(TargetPath);
                var files = dir.GetFiles();
                foreach (var file in files.Where(file => !CopyFile(TargetPath, file, "a")).Where(file => !CopyFile(TargetPath, file, "b")))
                {
                    Console.WriteLine("Other: " + file.Name);
                }
    
                Console.Read();
            }
    
            private static bool CopyFile(string dir, FileInfo file, string match)
            {
                if (!file.Name.Contains(match))
                {
                    return false;
                }
    
                dir = dir + "\\" + match.ToUpper();
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
    
                Console.WriteLine(file);
                file.CopyTo(Path.Combine(dir, file.Name), true);
                return true;
            }
