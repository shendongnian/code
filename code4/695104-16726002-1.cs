    public class A
    {
        private byte[] raw;
        public A()
        {
            raw = new byte[2];
        }
        public byte Low
        {
            get
            {
                return raw[0];
            }
            set
            {
                raw[0] = value;
            }
        }
   
        public byte High
        {
            get
            {
                return raw[1];
            }
            set
            {
                raw[1] = value;
            }
        }
    }
