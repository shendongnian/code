    public struct MyTest /* Of course, this isn't correct, because we'll inherit from System.ValueType. An enum should inherit from System.Enum */
    {
        private int _value; /* Should be marked to be treated specially */
        private MyTest(int value) /* Doesn't need to exist, since there's some CLR fiddling */
        {
           _value = value;
        }
	
        public static explicit operator int(MyTest value) /* CLR provides conversions automatically */
        {
           return value._value;
        }
        public static explicit operator MyTest(int value) /* CLR provides conversions automatically */
        {
           return new MyTest(value);
        }
        public static readonly MyTest A = new MyTest(1); /* Should be const, not readonly, but we can't do a const of a custom type in C#. Also, is magically implicitly converted without calling a constructor */
        public static readonly MyTest B = new MyTest(2); /* Ditto */
    }
