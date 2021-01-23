        private static int countWithReadLines(string filePath)
        {
            int count = 0;
            var lines = File.ReadLines(filePath);
            foreach (var line in lines) count++;
            return count;
        }
        private static int countWithReadLine(string filePath)
        {
            int count = 0;
            using (var sr = new StreamReader(filePath))      
                while (sr.ReadLine() != null)
                    count++;
            return count;
        }
        private static int countWithFileStream(string filePath, int bufferSize = 1024 * 4)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int count = 0;
                byte[] array = new byte[bufferSize];
                while (true)
                {
                    int length = fs.Read(array, 0, bufferSize);
                    for (int i = 0; i < length; i++)
                        if(array[i] == 10)
                            count++;
                    if (length < bufferSize) return count;
                }
            } // end of using
        }
