    [Serializable]
    public abstract class ColumnFormatterBase
    {
        public abstract string FormatCell(Data data);
    }
    [Serializable]
    public class ColumnFormatter1: ColumnFormatterBase
    {
        object SerializableProperty1 {get; set;}
        object SerializableProperty2 {get; set;}
        public override string FormatCell(Data data)
        {
            return // formatted result //;
        }
    }
    
