        private static unsafe string[] Scan(string hugeString, int subStringSize)
        {
            var results = new string[hugeString.Length / subStringSize];
            var gcHandle = GCHandle.Alloc(hugeString, GCHandleType.Pinned);
            var currAddress = (char*)gcHandle.AddrOfPinnedObject();
            for (var i = 0; i < results.Length; i++)
            {
                results[i] = new string(currAddress, 0, subStringSize);
                currAddress += subStringSize;
            }
            return results;
        }
            const int size = 3000000;
            const int subSize = 100;
            var stringBuilder = new StringBuilder(size);
            var random = new Random();
            for (var i = 0; i < size; i++)
            {
                stringBuilder.Append((char)random.Next(30, 80));
            }
            var hugeString = stringBuilder.ToString();
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                var strings = Scan(hugeString, subSize);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000); // 43
