            Stopwatch sw = new Stopwatch();
            sw.Start();
            string a = String.Empty;
            int i;
            long sum = 0, avg = 0, beginning = 0, end = 0;
            for (i = 0; i < 500000; i++) // nEntries is typically more than 500,000
            {
                beginning = sw.ElapsedMilliseconds;
                if (sw.ElapsedMilliseconds + avg > 200)
                    break;
                // Some processing
                a += "x";
                int s = a.Length * 100;
                Thread.Sleep(19);
                /////////////
                end = sw.ElapsedMilliseconds;
                sum += end - beginning;
                avg = sum / (i + 1);
                Console.WriteLine(s);
            }
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine(i + " " +sw.ElapsedMilliseconds);
            Console.ReadKey();
