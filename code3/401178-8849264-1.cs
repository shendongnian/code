    class Program
    {
        static void Main()
        {
            Console.WriteLine(IsNumber("0161 287 1234")); // false
            Console.WriteLine(IsNumber("08720 123 456")); // false
            Console.WriteLine(IsNumber("01612871234")); // true
            Console.WriteLine(IsNumber("08720123456")); // false because you overflowed Int32 which can store a maximum value of 2147483648
        }
    
        static bool IsNumber(string value)
        {
            int number1;
            return int.TryParse(value, out number1);
        }
    }
