    string Myfile = @"C:\MyDocument.txt";
    using(FileStream fs = new FileStream(Myfile, FileMode.Open, FileAccess.Read))
    {                    
        using(StreamReader sr = new StreamReader(fs))
        {
            while(!sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
            }
        }
    }
