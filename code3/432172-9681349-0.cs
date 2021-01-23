    struct MyStruct
    {
        public string Name;
        public int Age;
        public static MyStruct ParseString(string s)
        {
            var my = new MyStruct();
            
            Name = s.substring(0, 10);
            Age = int.Parse(s.substring(11))
        }
    }
