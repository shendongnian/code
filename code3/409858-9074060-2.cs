public static string TestEnumToString(TestEnum value)
{
    var result = new List<string>();
    if (value == TestEnum.Zero)
    {
        result.Add("Zero");
    }
    if (value == TestEnum.Nada)
    {
        result.Add("Nada");
    }
    if (value == TestEnum.Zilch)
    {
        result.Add("Zilch");
    }
    if ((value & TestEnum.One) != 0)
    {
        result.Add("One");
    }
    if ((value & TestEnum.Two) != 0)
    {
        result.Add("Two");
    }
    if ((value & TestEnum.Four) != 0)
    {
        result.Add("Four");
    }
            
    return string.Join(",", result);
}
