    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\Locations2.txt");
        foreach (string path in lines)
            if (File.Exists(path))
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Results.txt", true))
                {
                    file.WriteLine("File found" + "\t" + path);
                    Console.WriteLine("File found" + "\t" + path);
                    FileInfo fi = new FileInfo(path);
                    var size = fi.Length;
                    file.WriteLine("File Size in Bytes: {0}", size);
                    Console.WriteLine("File Size in Bytes: {0}", size);
                }
            else
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Results.txt", true))
                {
                    file.WriteLine("Does not Exist" + "\t" + path);
                    Console.WriteLine("Does not Exist" + "\t" + path);
                }
    }
