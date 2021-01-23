    public class FirstKind
    {
        public string Value { get; private set; }
    
        public FirstKind(string value)
        {
            this.Value = value;
        }
    
        public static implicit operator FirstKind(string value)
        {
            return new FirstKind(value);
        }
    
        public static implicit operator string(FirstKind value)
        {
            return value.Value;
        }
    }
