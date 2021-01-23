    class  AccSave
    {
        static string _acc;
        static public string acc { get { return _acc; } set { _acc = value; } }
        static public void clear()
        {
            _acc = "";
        }
       
    }
