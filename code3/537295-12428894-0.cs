        public static int DoSomething(Enum x) 
        {
            int xInt = (int)Convert.ChangeType(x, x.GetTypeCode());
            DoSomething(xInt);
        }
