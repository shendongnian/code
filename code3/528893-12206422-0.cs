            string test = "A quick brown fox jumps over a lazy dog.";
            int count = 1000 * 1000;
            Stopwatch watch = new Stopwatch();
            
            for (int i = 0; i < 4; i++)
            {
                string result = String.Empty;
                            
                watch.Restart();
                for (int c = 0; c < count; c++)
                {
                    switch (i)
                    {
                        case 0: // warmup
                            break;
                        case 1:
                            if (test.Contains("\""))
                            {
                                result = test.Replace("\"", "\"\"");
                            }
                            break;
                        case 2:
                            result = test.Replace("\"", "\"\"");
                            break;
                        case 3:
                            if (test.IndexOf('\"') >= 0)
                            {
                                result = test.Replace("\"", "\"\"");
                            }
                            break;
                    }
                }
                watch.Stop();
                Console.WriteLine("Test {0,16} {1,7:N3} ms {2}", 
                    new string[]{"Base","Contains-Replace","Replace","IndexOf-Replace"}[i],
                    watch.Elapsed.TotalMilliseconds,
                    result);
