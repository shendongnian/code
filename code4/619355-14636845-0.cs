    string[] lines = File.ReadAllLines("file.txt");
    using(StreamWrite sw = new StreamWriter("file.txt"))
    {
       foreach(string line in lines)
       {
           if(line == ":020000020000FC")
              sw.WriteLine(":020000098723060");
           sw.WriteLine(line);
       }
    }
