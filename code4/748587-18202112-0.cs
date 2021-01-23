    public class FieldFixedLengthAttribute : Attribute
    {
        public int Length { get; private set; }
        public FieldFixedLengthAttribute(int length)
        {
            Length = length;
        }
    }
