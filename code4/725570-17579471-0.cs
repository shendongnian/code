    Stopwatch sw = new Stopwatch();
   
    string testString = "tHiSISaSTRINGwiThInconSISteNTcaPITaLIZATion";
    
    sw.Start();
    for (int i = 0; i < 1000000; i++)
    {
        bool containsString = Regex.IsMatch(testString, "string", RegexOptions.IgnoreCase);
    }
    sw.Stop();
    Console.WriteLine("RX: " + sw.ElapsedMilliseconds);
    sw.Restart();
    for (int i = 0; i < 1000000; i++)
    {
         bool containsStringRegEx = testString.ToUpper().Contains("STRING");
    }
    sw.Stop();
    Console.WriteLine("Contains: " + sw.ElapsedMilliseconds);
    
    sw.Restart();
    for (int i = 0; i < 1000000; i++)
    {
          bool containsStringRegEx = testString.IndexOf("STRING", StringComparison.OrdinalIgnoreCase) >= 0 ;
    }
    sw.Stop();
    Console.WriteLine("IndexOf: " + sw.ElapsedMilliseconds);
