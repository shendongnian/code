    string file = @"C:\Temp\New Folder\New Text Document.txt";
    using(FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
    {                    
        using(StreamReader sr = new StreamReader(fs))
        {
            while(!sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
            }
        }
    }
