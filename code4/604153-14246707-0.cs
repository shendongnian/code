            private static int countFileLines(string filePath)
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    int i = 0;
                    while (r.ReadLine() != null)
                    {
                        i++;
                    }
                    return i;
                }
            }
    
            private static int countFileLines2(string filePath)
            {
                using (Stream s = new FileStream(filePath, FileMode.Open))
                {
                    int i = 0;
                    int b;
    
                    b = s.ReadByte();
                    while (b >= 0)
                    {
                        if (b == 10)
                        {
                            i++;
                        }
                        b = s.ReadByte();
                    }
                    return i + 1;
                }
            }
    
            private static int countFileLines3(string filePath)
            {
                using (Stream s = new FileStream(filePath, FileMode.Open))
                {
                    int i = 0;
                    byte[] b = new byte[bufferSize];
                    int n = 0;
    
                    n = s.Read(b, 0, bufferSize);
                    while (n > 0)
                    {
                        i += countByteLines(b, n);
                        n = s.Read(b, 0, bufferSize);
                    }
                    return i + 1;
                }
            }
    
            private static int countByteLines(byte[] b, int n)
            {
                int i = 0;
                for (int j = 0; j < n; j++)
                {
                    if (b[j] == 10)
                    {
                        i++;
                    }
                }
    
                return i;
            }
    
            private static int countFileLines4(string filePath)
            {
                return File.ReadLines(filePath).Count();
            }
