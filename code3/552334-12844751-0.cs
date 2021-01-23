    string line = System.String.Empty;
    using (StreamReader sr = new StreamReader("MyFile.txt")
    {
        while ((line = sr.ReadLine()) != null)
        {
             string[] tokens = line.Split(',');    
             LocalKeyWords.Add(tokesn[0], tokens[1]);
        }
    }
