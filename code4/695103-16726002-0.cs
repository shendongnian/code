    public class A
    {
        private byte[] raw;
        public A()
        {
            raw = new byte[4];
        }
        public char Low
        {
            get
            {
                return BitConverter.ToChar(raw, 0);
            }
            set
            {
                byte[] toWrite = BitConverter.GetBytes(value);
                Array.Copy(toWrite, 0, raw, 0, toWrite.Length);
            }
        }
   
        public char High
        {
            get
            {
                return BitConverter.ToChar(raw, 2);
            }
            set
            {
                byte[] toWrite = BitConverter.GetBytes(value);
                Array.Copy(toWrite, 0, raw, 2, toWrite.Length);
            }
        }
    }
