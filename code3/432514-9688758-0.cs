    class Program
    {
        public static void Main()
        {
            int d = 26990;
            byte[] bytes = BitConverter.GetBytes(d);
            string s = System.Text.Encoding.ASCII.GetString(bytes);
            // note that s will contain extra NULLs here so..
            s = s.TrimEnd('\0');
        }
    }
