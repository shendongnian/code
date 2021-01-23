    static void Main(string[] args)
    {
        string[] filesGroupList = new string[1];
        int x = 0;
        filesGroupList[x] = "String is here!";
        using (StringReader reader = new StringReader(filesGroupList[x]))
        {
            while ((filesGroupList[x] = reader.ReadLine()) != null)
            {
                Console.WriteLine("the string is here, I just checked");
                Console.WriteLine(filesGroupList[x]);
            }
        }
        Console.ReadLine();
    }
	
