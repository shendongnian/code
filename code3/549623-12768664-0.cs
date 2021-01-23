    public ValueAttribute : Attribute
    {
        public char Value { get; set; }
        public ValueAttribute(char value) { Value = value; }
    }
    private enum Operation
    {
        [Value(0x5E)]
        Power = 1,
        [Value(0x2F)]
        Division = 2,
        [Value(0x2A)]
        Multiplication = 3,
        [Value(0x2D)]
        Subtraction = 4,
        [Value(0x2B)]
        Addition = 5,
    }
    private static char[] GetOperators()
    {
        List<char> ExistingOperators = new List<char>();
        foreach (Operation enumOperator in Enum.GetValues(typeof(Operation)))
        {
                ExistingOperators.Add(enumOperator.Value());
                Console.WriteLine(enumOperator);
        }
        return ExistingOperators.ToArray<char>();
    }
    public static class Extensions
    {
        public static char Value(this Operation op)
        {
            var attr = typeof(Operation)
                .GetField(op.ToString())
                .GetCustomAttributes(typeof(ValueAttribute), false)[0]
                as ValueAttribute;
            return attr.Value;
        }
    }
    
