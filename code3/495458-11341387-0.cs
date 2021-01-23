        void ConcatenateAllSafe(StreamWriter output, params string[] files)
        {
            foreach (var f in files)
            {
                using(StreamReader rd = new StreamReader(f))
                {
                    string line = null;
                    while (null != (line = rd.ReadLine()))
                    {
                        output.WriteLine(line);
                    }
                }
            }
        }
        // This version will assume everything is sharing the same encoding
        void ConcatenateAllUnsafe(Stream output, params string[] files)
        {
            var data = new byte[1024 * 64];//64k should be enough for anyone
            foreach (string f in files)
            {
                using (Stream inStream = new FileStream(f, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    for (int offset = 0,
                             read; 0 != (read = inStream.Read(data, offset, data.Length)); offset += read)
                    {
                        output.Write(data, 0, read);
                    }
                }
            }
        }
