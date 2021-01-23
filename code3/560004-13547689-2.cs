    class Program
    {
        class MyType
        {
            public MyType(int i) { this.Value = i; }
            public void SetValue(int i) { this.Value = i; }
            public void SetSumValue(int a, int b) { this.Value = a + b; }
            public int Value { get; set; }
        }
        public static void Main()
        {
            Type type = typeof(MyType);
            var mi = type.GetMethod("SetValue");
            var obj1 = new MyType(1);
            var obj2 = new MyType(2);
            var action = DelegateBuilder.BuildDelegate<Action<object, int>>(mi);
            action(obj1, 3);
            action(obj2, 4);
            Console.WriteLine(obj1.Value);
            Console.WriteLine(obj2.Value);
            // Sample passing a default value for the 2nd param of SetSumValue.
            var mi2 = type.GetMethod("SetSumValue");
            var action2 = DelegateBuilder.BuildDelegate<Action<object, int>>(mi2, 10);
            action2(obj1, 3);
            action2(obj2, 4);
            Console.WriteLine(obj1.Value);
            Console.WriteLine(obj2.Value);
        }
    }
