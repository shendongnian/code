        static void Main(string[] args)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            var dInfo = new DirectoryInfo(path);
            DoStuff(dInfo);
            Console.ReadLine();
        }
        static void DoStuff(DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles())
            {
                Console.WriteLine(file.FullName);
            }
            foreach (var subDirectory in directory.GetDirectories())
            {
                DoStuff(subDirectory);
            }
        }
