    string test = "????log L 05/27/2012 - 08:02:57: \"Acid<1><STEAM_ID_PENDING><CT>\" say \"password somepass\"\n\0";
    Stopwatch timer = new Stopwatch();
    timer.Start();
    for (int n = 0; n < 10000000; n++)
    {
         string[] array = test.Split('\"');
         string password = array[3].Split(' ').Last(); //somepass
    }
    timer.Stop();
    TimeSpan time = timer.Elapsed;
    Console.WriteLine(String.Format("{0:00}:{1:00}:{2:00}", time.Minutes, time.Seconds, time.Milliseconds / 10));
    timer.Reset();
    timer.Start();
    for (int n = 0; n < 10000000; n++)
    {
        string password = string.Empty;
        for (int i = 0; i < test.Length - 8; i++)
             if (test.Substring(i, 8) == "password")
                 for (int j = i + 8; test[j] != '\"'; j++)
                     if (test[j] != ' ')
                          password += test[j]; 
    } //somepass
    
    timer.Stop();
    time = timer.Elapsed;
    Console.WriteLine(String.Format("{0:00}:{1:00}:{2:00}", time.Minutes, time.Seconds, time.Milliseconds / 10));
    timer.Reset();
    timer.Start();
    for (int n = 0; n < 10000000; n++)
    {
        string resultString = null;
        Regex regexObj = new Regex(@"""password (.*?)\\""\\n\\0""");
        resultString = regexObj.Match(test).Groups[1].Value; //somepass
    }
    timer.Stop();
    time = timer.Elapsed;
    Console.WriteLine(String.Format("{0:00}:{1:00}:{2:00}", time.Minutes, time.Seconds, time.Milliseconds / 10));
