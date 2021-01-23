    public static decimal sum<T>(IEnumerable<T> numbers) where T : IConvertible
    {
        decimal summation = 0.0m;
        foreach(var number in numbers){
            summation += number.ToDecimal(System.Globalization.CultureInfo.InvariantCulture);
        }
        return summation;
    }
