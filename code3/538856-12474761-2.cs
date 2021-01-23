     var value = "key{0},val1,val2,val3,val4,val5:";
     string newstr = "";
     for (int i = 0; i <= 1000; i++)
     {
         newstr += String.Format(value, i + 1);
     }
     var sw = new System.Diagnostics.Stopwatch();
     sw.Start();
     Dictionary<string, List<string>> mydictionary = new Dictionary<string, List<string>>();
     foreach (string item in newstr.Split(':'))
     {
         List<string> list = new List<string>(item.Split(','));
         mydictionary.Add(list[0], list);
     }
     sw.Stop();
     Console.WriteLine("Looping time: " + sw.Elapsed.ToString());
     sw.Reset();
     sw.Start();
     var result = newstr.Split(':')
                        .Select(line => line.Split(','))
                        .ToDictionary(bits => bits[0],
                                      bits => bits.Skip(1).ToList());
     sw.Stop();
     Console.WriteLine("LINQ time: " + sw.Elapsed.ToString());
     Console.ReadKey(); 
