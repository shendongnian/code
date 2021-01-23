    abstract class BaseMyClass
    {
        public BaseMyClass(arg1, arg2,...)
        {
            Init(arg1, arg2,...);
        }
        public int  IntVal1 { get {...}; set{...} }
        public byte IntVal2 { get {...}; set{...} }
        protected virtual Init(arg1, arg2,...)
        {
             //Init properties
        }
    }
    
    class MyCLass : BaseMyClass
    {
        public MyCLass(arg1, arg2, ...): base(arg1, arg2,...)
    }
    class AnotherMyCLass : BaseMyClass
    {
        public MyCLass(arg1, arg2, ...): base(arg1, arg2,...)
        protected override Init(arg1, arg2,...)
        {
             //Init properties
        }
    }
