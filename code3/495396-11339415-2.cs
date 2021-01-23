            Stopwatch sw = new Stopwatch();
            sw.Start();
            string a = String.Empty;
            int i;
            long sum = 0, avg = 0, beginning = 0, end = 0, avgCalculationOverhead = 5;
            for (i = 0; i < 700000; i++) // nEntries is typically more than 500,000
            {
                beginning = sw.ElapsedMilliseconds;
                if (sw.ElapsedMilliseconds + avg + avgCalculationOverhead > 200)
                    break;
                // Some processing
                a += "x";
                int s = a.Length * 100;
                //Thread.Sleep(19);
                /////////////
                end = sw.ElapsedMilliseconds;
                sum += end - beginning;
                avg = sum / (i + 1);
            }
            sw.Stop();
            Console.WriteLine(i + " " + sw.ElapsedMilliseconds);
            Console.ReadKey();
