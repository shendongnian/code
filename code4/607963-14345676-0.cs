        static string FindRecordBinary(string search, 
                                       string fileName, 
                                       Encoding encoding)
        {
            string line;
            using (FileStream fs = new FileStream(fileName, FileMode.Open,
                                                  FileAccess.Read,
                                                  FileShare.Read,
                                                  0x10000, true))
            {
                long min = 0;
                long max = fs.Length;
                long lastRecordStart = 0;
                byte[] recordBuffer = new byte[0x10000];
                while (true)
                {
                    long mid = (min + max) / 2;
                    fs.Seek(mid, SeekOrigin.Begin);
                    int b;
                    do
                    {
                        b = fs.ReadByte();
                    } while (b != -1 && b != '\n');
                    line = null;
                    if (lastRecordStart == fs.Position)
                        break;
                    lastRecordStart = fs.Position;
                    b = fs.ReadByte();
                    int bufPos = -1;
                    while (b != -1 && b != '\n' && b != '\r')
                    {
                        recordBuffer[++bufPos] = (byte)b;
                        b = fs.ReadByte();
                    }
                    if (bufPos == -1) continue;
                    line = encoding.GetString(recordBuffer, 0, bufPos + 1);
                    int compareResult = String.Compare(
                        line, 0, search, 0, 
                        Math.Min(line.Length, search.Length),
                        false);
                    if (0 == compareResult)
                        break;
                    else if (compareResult > 0)
                        max = lastRecordStart;
                    else
                        min = mid;
                }
            }
            return line;
        }
