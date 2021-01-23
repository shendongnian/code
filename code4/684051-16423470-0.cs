    interface IConverter
    {
        int Convert(string value);
    }
    
    class ASCIConverter : IConverter
    {
        public int Convert(string value)
        {
            //conversion implementation here
        }
    }
    
    class MyClass
    {
    
        string Input;
        IConverter Converter;
        public MyClass(string input, IConverter converter)
        {
            this.Input = input;
            this.Converter = converter;
        }
    
        public int GetConvertedValue()
        {
            return this.Converter.Convert(this.Input);
        }
    
    }
