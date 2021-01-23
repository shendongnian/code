    public stuct MyStruct
    {
        public int Age { get; private set; }
        public int Height { get; private set; }
        private char[] name;
        public char[] Name 
        {
            get { return name; }
            set
            {
                if (value.Length > 12) throw new Exception("Max length is 12");
                name = value;
            }
        }
        public MyStruct(int age, int height, char[] name)
        {
        }
    }
