    public static class OperandTypeExtensions
    {
        public static string ToShortName(this OperandType type)
        {
            switch (type)
            {
                case OperandType.None: return "<none>";
                case OperandType.Int32: return "i32";
                case OperandType.Int64: return "i64";
                default:
                    throw new NotSupportedException();
            }
        }
    }
