        public static string GetLineThreadSafe(this StreamReader sr)
        {
            lock (sr)
            {
                return sr.EndOfStream ? null : sr.ReadLine();
            }
        }
