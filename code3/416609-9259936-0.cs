    System.IO.StreamWriter file1 = System.IO.File.AppendText(path);
    System.IO.StreamReader file2 = new System.IO.StreamReader(path2)
    
    while(!file2.EndOfStream)
    {
        file1.WriteLine(file2.ReadLine());
    }
    
    file1.Close();
    file2.Close();
