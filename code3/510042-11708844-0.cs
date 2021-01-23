    using (StreamReader sr = new StreamReader("xmlfile.txt")) 
    {
        string line;
        while ((line = sr.ReadLine()) != null) 
        {
             File.WriteAllText("mynewxmfile.xml", MyEncryptMethod(line));
        }
    }
