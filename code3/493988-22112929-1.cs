    public static class helper
    {
        private static readonly KeysConverter Kc = new KeysConverter();
		/// <summary>
        /// Filters the keys for numeric entry keys
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        public static bool NumericFilterKeyData(Keys keyData)
        {
		    var keyChar = Kc.ConvertToString(keyData);
            return !char.IsDigit(keyChar[0])
                   && keyData != Keys.Decimal
                   && keyData != Keys.Delete
                   && keyData != Keys.Tab
                   && keyData != Keys.Back
                   && keyData != Keys.Enter
                   && keyData != Keys.OemPeriod
                   && keyData != Keys.NumPad0
                   && keyData != Keys.NumPad1
                   && keyData != Keys.NumPad2
                   && keyData != Keys.NumPad3
                   && keyData != Keys.NumPad4
                   && keyData != Keys.NumPad5
                   && keyData != Keys.NumPad6
                   && keyData != Keys.NumPad7
                   && keyData != Keys.NumPad8
                   && keyData != Keys.NumPad9;
        }
		
		/// <summary>
        /// Determines if a type is numeric.  Nullable numeric types are considered numeric.
        /// </summary>
        /// <remarks>
        /// Boolean is not considered numeric.
        /// </remarks>
        public static bool IsNumericType(Type type)
        {
            if (type == null)
            {
                return false;
            }
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsNumericType(Nullable.GetUnderlyingType(type));
                    }
                    return false;
            }
            return false;
        }
        /// <summary>
        /// Tests if the Object is of a numeric type This is different than testing for NumericType
        /// as this expects an object that contains an expression like a sting "123"
        /// </summary>
        /// <param name="expression">Object to test</param>
        /// <returns>true if it is numeric</returns>
        public static bool IsNumeric(Object expression)
        {
            if (expression == null || expression is DateTime)
                return false;
            if (expression is Int16 || expression is Int32 || expression is Int64 || expression is Decimal ||
                expression is Single || expression is Double || expression is Boolean)
                return true;
            try
            {
                if (expression is string)
                {
                    if (
                        expression.ToString()
                            .IndexOfAny(
                                @" abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOOPQRSTUVWXYZ!@#$%^&*?<>[]|+-*/\'`~_"
                                    .ToCharArray()) != -1) return false;
                }
                else
                {
                    Double.Parse(expression.ToString());
                }
                return true;
            }
            catch
            {
            } // just dismiss errors but return false
            return false;
        }
	}
