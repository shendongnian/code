            List<string> StringList = new List<string>();
            for (int i = 0; i < 10000; i++)
            {
                StringList.Add(DateTime.Now.Ticks + " abc ");
            }
            string temp;
            Dictionary<string, string> StringsToReplace = new Dictionary<string, string>();
            StringsToReplace.Add("1", ".1.");
            StringsToReplace.Add("a", "z");
            StringsToReplace.Add("b", "x");
            StringsToReplace.Add("c", "v");
            StringsToReplace.Add("d", "u");
            StringsToReplace.Add("e", "t");
            long ReplaceElapsedTime = 0;
            long ContainsReplaceElapsedTime = 0;
            int TotalIterations = 10000;
            for (int j = 0; j < TotalIterations; j++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                for (int i = 0; i < StringList.Count; i++)
                {
                    foreach (KeyValuePair<string, string> CurrentPair in StringsToReplace)
                    {
                        temp = StringList[i].Replace(CurrentPair.Value, CurrentPair.Key);
                    }
                }
                stopWatch.Stop();
                ReplaceElapsedTime += stopWatch.ElapsedMilliseconds;
                
                stopWatch.Reset();
                stopWatch.Start();
                for (int i = 0; i < StringList.Count; i++)
                {
                    foreach (KeyValuePair<string, string> CurrentPair in StringsToReplace)
                    {
                        if (StringList[i].Contains(CurrentPair.Value))
                            temp = StringList[i].Replace(CurrentPair.Value, CurrentPair.Key);
                    }
                }
                stopWatch.Stop();
                ContainsReplaceElapsedTime += stopWatch.ElapsedMilliseconds;
            }
            Console.WriteLine(string.Format("Replace: {0} ms", ReplaceElapsedTime/TotalIterations));
            Console.WriteLine(string.Format("Contains > Replace: {0} ms", ContainsReplaceElapsedTime/TotalIterations));
            Console.ReadLine();
