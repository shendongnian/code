    class MyClassB : MyClassA
    {
        public static MyClassB Create()
        {
            try
            {
                return new MyClassB();
            }
            catch
            {
                // try to handle
            }
        }
    }
