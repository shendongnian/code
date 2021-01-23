    public static explicit operator Digit(byte b)  // explicit byte to digit conversion operator
    {
        Digit d = new Digit(b);  // explicit conversion
        System.Console.WriteLine("Conversion occurred.");
        return d;
    }
