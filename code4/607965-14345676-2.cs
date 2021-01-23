        static string FindRecordBinary(string search, string fileName)
        {
            using (StreamReader fs = new StreamReader(fileName))
            {
                long min = 0; // TODO: What about header row?
                long max = fs.BaseStream.Length;
                while (min + 1 < max)
                {
                    long mid = (min + max) / 2;
                    fs.BaseStream.Position = mid;
                    fs.DiscardBufferedData();
                    if (min !=0 || mid != 0) fs.ReadLine();
                    string line = fs.ReadLine();
                    if (line == null) { min = mid; continue; }
                    int compareResult;
                    if (line.Length > search.Length)
                        compareResult = String.Compare(
                            line, 0, search, 0, search.Length, false );
                    else
                        compareResult = String.Compare(line, search);
                    if (0 == compareResult) return line;
                    else if (compareResult > 0) max = mid;
                    else min = mid;
                }
            }
            return null;
        }
