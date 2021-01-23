    class Base
    {
        public Base()
        {
            obj = new ObjNeedParam(GetParamVal());
        }
        protected virtual int GetParamVal() { return 1; }
    }
    
    class Derived : Base
    {
        protected override int GetParamVal() { return 2; }
    }
