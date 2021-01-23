    class MyClass
    {
        public MyIndexerClass Sites;
        public class MyIndexerClass
        {
            private byte[] data;
            public MyIndexerClass()
            {
                this.data = new byte[0];
            }
            public MyIndexerClass(byte[] Data)
            {
                this.data = Data;
            }
            public byte this[int index]
            {
                get
                {
                    return data[index];
                }
                set
                {
                    data[index] = value;
                }
            }
        }
        public MyClass()
        {
            this.Sites = new MyIndexerClass();
        }
        public MyClass(byte[] data)
        {
            this.Sites = new MyIndexerClass(data);
        }
    }
