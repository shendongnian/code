    public static int? NumOrZero(this int? num)
    {
        return num.HasValue ? num.Value : 0;
    }
    public static int? Add(this int? num1, int? num2)
    {
        return num1.NumOrZero() + num2.NumOrZero();
    }
