            List<string> StringList = new List<string>();
            for (int i = 0; i < 10000; i++)
            {
                StringList.Add(DateTime.Now.Ticks + " abc ");
            }
            string temp;
            
            KeyValuePair<string, string>[] StringsToReplace = new KeyValuePair<string, string>[6];
            // Use array to avoid dictionary access cost
            StringsToReplace[0] = new KeyValuePair<string,string>("1", ".1.");
            StringsToReplace[1] = new KeyValuePair<string,string>("a", "z");
            StringsToReplace[2] = new KeyValuePair<string,string>("b", "x");
            StringsToReplace[3] = new KeyValuePair<string,string>("c", "v");
            StringsToReplace[4] = new KeyValuePair<string,string>("d", "u");
            StringsToReplace[5] = new KeyValuePair<string,string>("e", "t");
            int TotalIterations = 100;
            Stopwatch stopWatch1 = new Stopwatch();
            Stopwatch stopWatch2 = new Stopwatch();
            GC.Collect(); // remove influence of garbage objects
            for (int j = 0; j <= TotalIterations; j++)
            {
                stopWatch1.Start(); // StopWatch Start/Stop does its own accumation
                for (int i = 0; i < StringList.Count; i++)
                {
                    for (int k = 0; k < StringsToReplace.Length; k++)
                    {
                        temp = StringList[i].Replace(StringsToReplace[k].Value, StringsToReplace[k].Key);
                    }
                }
                stopWatch1.Stop();
                stopWatch2.Start();
                for (int i = 0; i < StringList.Count; i++)
                {
                    for (int k = 0; k < StringsToReplace.Length; k++)
                    {
                        if (StringList[i].Contains(StringsToReplace[k].Value))
                            temp = StringList[i].Replace(StringsToReplace[k].Value, StringsToReplace[k].Key);
                    }
                }
                stopWatch2.Stop();
                if (j == 0) // discard first run, warm only
                {
                    stopWatch1.Reset();
                    stopWatch2.Reset();
                }
            }
            // Elapsed.TotalMilliseconds return in double, more accurate than ElapsedMilliseconds
            Console.WriteLine("Replace           : {0:N3} ms", stopWatch1.Elapsed.TotalMilliseconds / TotalIterations);
            Console.WriteLine("Contains > Replace: {0:N3} ms", stopWatch2.Elapsed.TotalMilliseconds / TotalIterations);
