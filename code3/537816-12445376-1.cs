    public class ScannableString : ScannableStringBase
    {
        public ScannableString(string value)
        {
            this.stringValue = value;
        }
        
        private readonly string stringValue;
        
        public override int Length {
            get {
                return stringValue.Length;
            }
        }
        
        public override char this[int index] {
            get {
                return stringValue[index];
            }
        }
    }
    public class ScannableStringBuilder : ScannableStringBase
    {
        public ScannableString(stringBuilder value)
        {
            this.stringBuilder = value;
        }
        
        private readonly string stringBuilder;
        
        public override int Length {
            get {
                return stringBuilder.Length;
            }
        }
        
        public override char this[int index] {
            get {
                return stringBuilder[index];
            }
        }
    }
