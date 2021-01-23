            public static IEnumerable<string> GetEnumirator(this StreamReader sr)
        {
            while (!sr.EndOfStream)
            {
                yield return sr.ReadLine();
            }
        }
        public static void ProcessParalel(this StreamReader sr, Action<string> action)
        {
            sr.GetEnumirator().AsParallel().ForAll(action);
        }
        public static void ProcessTo(this StreamReader sr, BinaryWriter bw, Action<BinaryWriter, string> action, FileProcessOptions fpo = null)
        {
            sr.ProcessParalel(line =>
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryWriter lbw = new BinaryWriter(ms);
                    action(lbw, line);
                    ms.Seek(0, SeekOrigin.Begin);
                    lock (bw)
                    {
                        ms.WriteTo(bw.BaseStream);
                    }
                }
            });
        }
