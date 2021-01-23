    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class BitfieldAttribute : Attribute 
    { 
        public BitfieldAttribute(int position, int length) 
        { 
            this.Position = position; 
            this.Length = length; 
        } 
        public int Position { get; private set; }
        public int Length { get; private set; }
    }
    
