            var source = new Bitmap(2000, 2000);
            var li = new List<Bitmap>();
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                li.Add((Bitmap)source.Clone());
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine(li.Count);
            li[4321].SetPixel(1234, 123, Color.Blue);
            Console.WriteLine(li[1234].GetPixel(1234, 123)); // checks if a pixel of another clone also changed to blue
