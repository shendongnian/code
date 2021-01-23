    string str = @"1009 10.32.0.28 03/05/2012 09:11:48 The license expires in 1192 day(s).";
    StreamReader sr = new StreamReader(@"event_history.txt");
    string allRead = sr.ReadToEnd();
    
    if(allRead.Contains(str))
    {
        Console.WriteLine("found\n");
    }
    else
    {
        Console.WriteLine("not found\n");
    }
