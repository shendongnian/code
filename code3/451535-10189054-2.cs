    public static class Extensions
    {
        public static byte[] GetFile(this string filename)
        {
            try { return File.ReadAllBytes(filename); }
            catch { return null; }
        }
    }
