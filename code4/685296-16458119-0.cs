     Stopwatch sw = Stopwatch.StartNew(); 
     StringBuilder str = new StringBuilder();
     
     for (int i = 0; i < 1000000; i++)
     {
          str.AppendLine(i.ToString());
     }
     sw.Stop();
     Console.WriteLine(sw.Elapsed);
     
     str = new StringBuilder();
     sw.Restart();
     
     Parallel.For(0,1000000,i =>
                    {
                        str.AppendLine(i.ToString());
                    });              
    
     sw.Stop();
     Console.WriteLine(sw.Elapsed);
