    public sealed class FixedWidth96Converter : ConverterBase
    {
        public override string FieldToString(object from)
        {
            string val = from as string;
            if (!string.IsNullOrWhiteSpace(val))
            {
                return val.PadLeft(96, ' ');
            }
            return base.FieldToString(from);
        }
        public override object StringToField(string from)
        {
            return from;
        }
    }
