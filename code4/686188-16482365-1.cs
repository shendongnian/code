    public static class IntegerMethods
    {
        public static int Add(this int i, int value)
        {
            return i + value;
        }
    }
    int i = 0;
    i = i.Add(2); // This could be an "extension method" call.
    i = IntegerMethods.Add(i, 2); // This would be the regular static method call.
