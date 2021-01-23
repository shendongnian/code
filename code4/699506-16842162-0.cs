    public class SomeClass
    {
        FileStream _file = null;
        public SomeClass(FileStream f)
        {
            _file = f;
        }
        void WriteString(string s)
        {
            byte[] buf = Encoding.UTF8.GetBytes(s);
            _file.Write(buf, 0, buf.Length);
        }
    }
