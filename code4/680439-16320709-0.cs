        public static void Read()
        {
            var fs = new FileStream(@"G:\test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            int lastReadCount = 0;
            while (true)
            {
                var totalCountOfFile = fs.Length;
                if (lastReadCount < totalCountOfFile)
                {
                    var buffer = new byte[1024];
                    int count = fs.Read(buffer, 0, buffer.Length);
                    lastReadCount += count;
                    Display(buffer);
                }
                Thread.Sleep(5000);
            }
        }
        private static void Display(byte[] buffer)
        {
            var text = Encoding.UTF8.GetString(buffer.Where(p=>p != 0).ToArray());
            Console.Write(text);
        }
