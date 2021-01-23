    public class NumericValue
    {
        double value;
        enum SerializationType { Int, UInt, Double, Float };
        SerializationType serializationType;        
    
        public void SetValue(int value)
        {
            this.value = value;
            this.serializationType = SerializationType.Int
        }
        ... etc ...
        public byte[] GetBytes()
        {
            switch(this.serializationType)
            {
                case SerializationType.Int:
                    return BitConverter.GetBytes((int)this.value);
                ... etc ...
