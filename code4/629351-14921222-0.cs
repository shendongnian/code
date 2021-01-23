     public static class RecursiveTest
    {
        public static string Foo(DirectoryInfo currentPath)
        {
            if (!currentPath.Exists) return string.Empty;
            foreach (var directory in currentPath.EnumerateDirectories())
                Console.WriteLine("Directory {0}", directory.Name);
            foreach (var file in currentPath.EnumerateFiles())
                Console.WriteLine("File {0}", file.Name);
            while(true)
            {
                Console.WriteLine("Choose directory or file: ");
                string chosenPath = Console.ReadLine();
                string newPath = Path.Combine(currentPath.FullName, chosenPath);
                if(Directory.Exists(newPath))
                    return Foo(new DirectoryInfo(newPath));
                if(File.Exists(newPath))
                    return newPath;
                Console.WriteLine("File {0} doesn't exist!", newPath);
            }
        }
    }
