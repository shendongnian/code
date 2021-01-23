    class Test
    {
        public Test(int x, string y)
        {
            fields = new Fields(x, y);
        }
        public int X
        {
            get
            {
                return fields.X;
            }
            set
            {
                fields.X = value;
            }
        }
        public string Y
        {
            get
            {
                return fields.Y;
            }
            set
            {
                fields.Y = value;
            }
        }
        struct Fields
        {
            public Fields(int x, string y)
            {
                X = x;
                Y = y;
            }
            public int    X;
            public string Y;
            // Uncomment this and you get an error:
            // public double Z;
        }
        Fields fields;
    }
