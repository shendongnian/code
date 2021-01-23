    public static class NumericalHelper {
        public static double AsDouble(this object value, out bool success) {
            if (value is sbyte || value is byte || value is short || value is ushort || value is int || value is uint || value is long || value is decimal || value is ulong || value is float || value is double || value.GetType().IsEnum) {
                success = true;
                return Convert.ToDouble(value);
            }
            success = false;
            return 0;
        }
    }
