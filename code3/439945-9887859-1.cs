    private static class UnboxT<T>
    {
        internal static readonly Converter<object, T> Unbox;
    
        static UnboxT()
        {
           DataRowExtensions.UnboxT<T>.Unbox =  
              new Converter<object, T>(DataRowExtensions.UnboxT<T>.ValueField);
        }
    
        private static T ValueField(object value)
        {
            if (DBNull.Value == value)
            {
                // You get this exception 
                throw DataSetUtil.InvalidCast(Strings.DataSetLinq_NonNullableCast(typeof(T).ToString()));
            }
            return (T) value;
        }
    }
