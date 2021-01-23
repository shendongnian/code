            var sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                var y = typeof(Program).ToString();
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            
            sw.Restart();
            for (int i = 0; i < 10000000; i++)
            {
                var y = typeReference.ToString();
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
