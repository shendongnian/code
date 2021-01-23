    public enum OperatorType
    {
        [EnumKey(">=", "GreaterOrEqual")]
        GreaterOrEqual,
        [EnumKey(">", "Greater")]
        Greater,
        [EnumKey("<", "Less")]
        Less,
        [EnumKey("<=", "LessOrEqual")]
        LessOrEqual,
        [EnumKey("==", "Equal")]
        Equal,
        [EnumKey("Between", "Between")]
        Between,
        [EnumKey("Around", "Around")]
        Around
    }
