    static class BigIntegerEx
    {
        private static Func<BigInteger, uint[]> getUnderlyingBitsArray;
        private static Func<BigInteger, int> getUnderlyingSign;
        static BigIntegerEx()
        {
            getUnderlyingBitsArray = CompileFuncToGetPrivateField<BigInteger, uint[]>("_bits");
            getUnderlyingSign = CompileFuncToGetPrivateField<BigInteger, int>("_sign");
        }
        private static Func<TObject, TField> CompileFuncToGetPrivateField<TObject, TField>(string fieldName)
        {
            var par = Expression.Parameter(typeof(TObject));
            var field = Expression.Field(par, fieldName);
            var lambda = Expression.Lambda(field, par);
            return (Func<TObject, TField>)lambda.Compile();
        }
        
        public static uint[] GetUnderlyingBitsArray(this BigInteger source)
        {
            return getUnderlyingBitsArray(source);
        }
        public static int GetUnderlyingSign(this BigInteger source)
        {
            return getUnderlyingSign(source);
        }
    }
