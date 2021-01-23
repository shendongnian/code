    public delegate int GetDigitsDelegate(ref Decimal value);
    
    public class DecimalHelper
    {
        public static readonly DecimalHelper Instance = new DecimalHelper();
    
        public readonly GetDigitsDelegate GetDigits;
        public readonly Expression<GetDigitsDelegate> GetDigitsLambda;
    
        public DecimalHelper()
        {
            GetDigitsLambda = CreateGetDigitsMethod();
            GetDigits = GetDigitsLambda.Compile();
        }
    
        private Expression<GetDigitsDelegate> CreateGetDigitsMethod()
        {
            var value = Expression.Parameter(typeof(Decimal).MakeByRefType(), "value");
    
            var digits = Expression.RightShift(
                Expression.And(Expression.Field(value, "flags"), Expression.Constant(~Int32.MinValue, typeof(int))), 
                Expression.Constant(16, typeof(int)));
    
            //return (value.flags & ~Int32.MinValue) >> 16
    
            return Expression.Lambda<GetDigitsDelegate>(digits, value);
        }
    }
