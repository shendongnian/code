    public class ReadOrWriteText<T>
    {
        private T _value;
        bool IsReadOnly { get; set; }
        
        public T Value 
        { 
           get { return _value; }
           set { if (IsReadOnly) return; _value = value; }
        }
    }
