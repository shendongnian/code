public static class TestEnumFormatter
{
    public static string TestEnumToString(TestEnum value)
    {
        switch (value)
        {
            case TestEnum.Zero:
                return "Zero"; // Or Nada, or Zilch, whichever you prefer
                break;
            case TestEnum.One:
                return "One";
                break;
            default:
                throw new ArgumentException();
                break;
        }
    }
}
