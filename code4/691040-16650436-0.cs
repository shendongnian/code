    public class MyConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            // you might like to check for nulls first...
            string output = from.Replace("%", "");
            // return Int32 because srv_tx_iva is Int32
            return Convert.ToInt32(output); 
        }
        public override string FieldToString(object from)
        {
            return from.ToString();
        }
    }
