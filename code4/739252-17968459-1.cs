    public class TransactionStatusConverter : IStringToTypeConverter<TransactionStatus>
    {
        public TransactionStatus FromString(string value)
        {
            return (TransactionStatus)Enum.Parse(typeof(TransactionStatus), value, true);
        }
        public object FromStringUntyped(string value)
        {
            return FromString(value);
        }
        public string ToString(TransactionStatus value)
        {
            return value.ToString();
        }
        public string ToString(object value)
        {
            return ToString((TransactionStatus)value);
        }
    }
