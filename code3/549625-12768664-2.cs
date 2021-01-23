    public IndexAttribute : Attribute
    {
        public int Index { get; set; }
        public IndexAttribute(int index) { Index = index; }
    }
    private enum Operation
    {
        [Index(1)]
        Power = 0x5E,
        [Index(2)]
        Division = 0x2F,
        [Index(3)]
        Multiplication = 0x2A,
        [Index(4)]
        Subtraction = 0x2D,
        [Index(5)]
        Addition = 0x2B,
    }
    public struct Datum
    {
        int Index { get; set; }
        char Value { get; set; }
        Operation Op { get; set; }
    }
    private static char[] GetOperators()
    {
        IEnumerable<Datum> data = new List<Datum>();
        foreach (Operation enumOperator in Enum.GetValues(typeof(Operation)))
        {
            data.Add(new Datum 
            { 
                Index = enumOperator.Index(), 
                Value = (char)enumOperator,
                Op = enumOperator
            });
        }
        // assuming you can use LINQ
        data = data.OrderBy(d => d.Index);
        data.Foreach(d => Console.WriteLine(d => d.Op));
        return data.Select(d => d.Value).ToArray();
    }
    public static class Extensions
    {
        public static char Index(this Operation op)
        {
            var attr = typeof(Operation)
                .GetField(op.ToString())
                .GetCustomAttributes(typeof(IndexAttribute), false)[0]
                as IndexAttribute;
            return attr.Index;
        }
    }
    
