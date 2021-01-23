    public class A_bool
    {
        public bool a;
       
        public class B_bool : A_bool
        {
            public bool b;
        }
    }
    public class A_char
    {
        public char a;
        public class B_bool : A_bool
        {
            public char b;
        }
    }
    public class A_int
    {
        public int a;
        public class B_char : A_char
        {
            public int b;
            public class C_bool : A_char.B_bool
            {
                public int c;
            }
        }
    }
