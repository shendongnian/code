    class ConversionStub<T> : DynamicObject
    {
        private readonly T input;
        public ConversionStub(T input){
            this.input = input;
        }
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if(/* you can do it*/ )
            {
                result = // your code here
                return true;
            }
            result = null;
            return false;
        }
    }
