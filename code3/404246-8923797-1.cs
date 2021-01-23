    public class ClassB
    {
        private readonly _classA = new ClassA();
        public int? shouldBeInteger
        {
            get
            {
                return (this._classA._shouldBeInteger != null)
                    ? Convert.ToInt32(Convert.ToDouble(this._classA._shouldBeInteger))
                    : new int?();
           }
            set
            {
                this._classA._shouldBeInteger = Convert.ToString(value);
            }
        } 
    }
