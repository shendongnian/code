    public static class GlobalClass
    {
        static GlobalClass()
        {
            GlobalClass._globalid = 0;
        }
        private static int _globalid;
        public static int GlobalID
        {
            get
            {
                return _globalid;
            }
        }
        //...
    }
