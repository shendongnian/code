        static void Main()
        {
            MyDouble x = 0;
            Console.WriteLine(x * LongOperation);
            MyDouble y = 5;
            Console.WriteLine(y * OperationReturningZero * LongOperation);
            Console.ReadLine();
        }
        private static double LongOperation()
        {
            Console.WriteLine("LongOperation");
            return 5;
        }
        private static double OperationReturningZero()
        {
            Console.WriteLine("OperationReturningZero");
            return 0;
        }
    }
    class MyDouble
    {
        private static double epsilon = 0.00000001;
        private double value;
        public MyDouble(double value)
        {
            this.value = value;
        }
        public static MyDouble operator *(MyDouble left, Func<double> right)
        {
            Console.WriteLine("* (MyDouble, Func<double>)");
            return Math.Abs(left.value) < epsilon ? new MyDouble(0) : new MyDouble(left.value * right());
        }
        public static MyDouble operator *(MyDouble left, MyDouble right)
        {
            Console.WriteLine("* (MyDouble, MyDouble)");
            return new MyDouble(left.value * right.value);
        }
        public static implicit operator double(MyDouble myDouble)
        {
            Console.WriteLine("cast to double");
            return myDouble.value;
        }
        public static implicit operator MyDouble(double value)
        {
            Console.WriteLine("cast to MyDouble");
            return new MyDouble(value);
        }
    }
