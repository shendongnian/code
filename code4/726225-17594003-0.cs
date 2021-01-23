    static void Main(string[] args)
        {
            FileStream f = new FileStream("test", FileMode.CreateNew);
            using (StreamWriter w = new StreamWriter(f))
            {
                w.Write(Compress("hello"));
            }
        }
        public static string Compress(string s)
        {
            var bytes = Encoding.Unicode.GetBytes(s);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    msi.CopyTo(gs);
                }
                return Convert.ToBase64String(mso.ToArray());
            }
        }
