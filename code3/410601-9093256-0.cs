    List<string> values = new List<string>();
    using (StreamReader sr = new StreamReader(filePath))
    {
        sr.ReadLine();
        while (sr.Peek() != -1)
        {
            string line = sr.ReadLine();
            List<string> lineValues = line.Split(',').ToList();
            
            //***//
        }
    }
