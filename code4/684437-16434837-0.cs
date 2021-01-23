        static void Main(string[] args)
        {
            Console.WriteLine(getRelativeValue(2, 360, 340)); //-22
            Console.WriteLine(getRelativeValue(2, 360, 22));  // 20
            Console.WriteLine(getRelativeValue(2, 360, 178)); // 176
            Console.Read();
        }
        static int getRelativeValue(int point, int upperBound, int value)
        {
            value %= upperBound;
            int lowerBoundPoint = -(upperBound - value + point);
            int upperBoundPoint = (value - point);
            if (Math.Abs(lowerBoundPoint) > Math.Abs(upperBoundPoint))
            {
                return upperBoundPoint;
            }
            else
            {
                return lowerBoundPoint;
            }
        }
