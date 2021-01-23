    using (StreamWriter file = new StreamWriter(@"C:\test.csv", true))
    {
        foreach (string s in MyListString)
        {
            Console.WriteLine(s); // Display all the data
            file.WriteLine(s);    // Write only a part of it
        }
    }
