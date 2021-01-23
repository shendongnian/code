    class A
    {
        public static int Flag = 0;
    }
    class B
    {
        public void bfunc()
        {
            if (A.Flag == 0)
            {
                A.Flag = 1;
            }
        }
    }
