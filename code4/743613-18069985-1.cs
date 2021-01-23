    class  AccSave
    {
        static string _acc;
        public static string acc { get { return _acc; } set { _acc = value; } }
        public static void clear()
        {
            _acc = "";
        }
       
    }
