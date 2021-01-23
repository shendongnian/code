    public static class OperandTypeExtensions
    {
        public static string ToShortName(this OperandType type)
        {
            Contract.Requires<InvalidEnumArgumentException>(Enum.IsDefined(typeof(OperandType), type));
            switch (type)
            {
                case OperandType.Int32: return "i32";
                case OperandType.Int64: return "i64";
                default:
                    return "<none>";
            }
        }
    }
