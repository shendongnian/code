    private abstract class GlobalQueryParam<TValue> where TValue : struct
    {
        public readonly TValue Low;
        public TValue Val; 
        protected TValue dbVal = default(TValue);
        public TValue GetDBVal()
        {
            return  dbVal;
        }
        public abstract bool SetDBVal(TValue value);
        public abstract TValue Parse(string dbVal);
        public GlobalQueryParam(TValue low)
        {
            this.Low = low;
        }
    }
    public class GlobalQueryParamInt : GlobalQueryParam<int>
    {
        public int Parse(string dbVal)
        {
            return (this.Val = int.Parse(dbVal));
        }
        public override bool SetDBVal(int value)
        {
            return true;
        }
        public GlobalQueryParamInt(int low = 0) : base(low) { }
    }
