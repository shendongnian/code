    string format = "{0}";
    List<string> parms = new List<string> { "Hello" };
	
    if (DateTime.Now.Ticks % 2 == 0)
    {
        format += " {1}";
        parms.Add("World");
    }
	
    Console.WriteLine(format, parms.ToArray());
