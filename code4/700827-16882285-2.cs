            var newStr2 = new Program().GetString(a, take, skip);
            var newstr = String.Join("", a.Where((c, i) => i % (skip + take) < take));
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                newStr2 = new Program().GetString(a, take, skip);
            }
            sw.Stop();
            Console.WriteLine("my way: " + sw.Elapsed.ToString());
            sw.Reset();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                newstr = String.Join("", a.Where((c, iv) => iv % (skip + take) < take));
            }
            sw.Stop();
            Console.WriteLine("I4V way: " + sw.Elapsed.ToString());
