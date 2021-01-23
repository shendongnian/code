      for (int t = 1; t != 10; t++)
            {
                var s = new System.Diagnostics.Stopwatch();
                var r = new Random(123456789);   //r
                int[] randomSet = new int[1000]; //a
                for (int i = 0; i < 1000; i++)   //n
                    randomSet[i] = r.Next();     //dom
                long _ternary = 0; //store
                long _if = 0;      //time
                int max = 0; //result
                s.Start();
                for (int q = 0; q < 1000000; q++)
                {
                    for (int i = 0; i < 1000; i++)
                        max = max > randomSet[i] ? max : randomSet[i];
                }
                s.Stop();
                _ternary = s.ElapsedMilliseconds;
                max = 0;
                s = new System.Diagnostics.Stopwatch();
                s.Start();
                for (int q = 0; q < 1000000; q++)
                {
                    for (int i = 0; i < 1000; i++)
                        if (max > randomSet[i])
                            max = max; // I think the compiler may remove this but not for the ternary causing the speed difference.
                        else
                            max = randomSet[i];
                }
                s.Stop();
                _if = s.ElapsedMilliseconds;
                Console.WriteLine("--Run #" + t+"--");
                Console.WriteLine("Type   | Milliseconds\nTernary {0}\nIf     {1}\n%: {2}", _ternary, _if,((decimal)_if/(decimal)_ternary).ToString("#.####"));
            }
