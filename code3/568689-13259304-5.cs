    public class ExponentClass
    {
        public double Value { get; set; }
        [System.Runtime.CompilerServices.SpecialName]
        public static ExponentClass op_Exponent(ExponentClass o1, ExponentClass o2)
        {
            return new ExponentClass { Value = Math.Pow(o1.Value, o2.Value) };
        }
    }
