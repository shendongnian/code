    using(System.IO.StreamReader sr = new System.IO.StreamReader("test.txt"))
    {
        string line;
        while((line = sr.ReadLine()) != null)
        {
        	string[] split = line.Split(',');
        	//...
        }
    }
