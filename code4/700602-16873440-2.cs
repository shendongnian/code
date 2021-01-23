    class MyValue {
        public int Value { get; set; }
    }
    MyValue b = new MyValue { Value = 5 }; 
    MyValue a = b;
    b.Value = 2;
