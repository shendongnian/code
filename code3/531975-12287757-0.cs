    public class ByPass
    {
        public ByPass(Stream s1, Stream s2)
        {
            Task.Factory.StartNew(() => Process(s1, s2));
            Task.Factory.StartNew(() => Process(s2, s1));
        }
        public void Process(Stream sIn, Stream sOut)
        {
            byte[] buf = new byte[0x10000];
            while (true)
            {
                int len = sIn.Read(buf, 0, buf.Length);
                sOut.Write(buf, 0, len);
            }
        }
    }
