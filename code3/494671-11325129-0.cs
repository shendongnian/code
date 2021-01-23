    using (StreamWriter sw = File.AppendText("File2.txt")) 
    {
        foreach (string line in File.ReadLines(@"d:\File1.txt"))
        {
            if (line.Contains("TheWordInLine"))//This is the line you want by matching something
            {
                    sw.WriteLine("line);
            }
        }
    }
