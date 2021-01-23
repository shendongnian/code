    abstract class BaseMyClass
    {
        public BaseMyClass(arg1, arg2,...)
        {
            Init(arg1, arg2,...);
        }
        public int  IntVal1 { get {...}; set{...} }
        public byte IntVal2 { get {...}; set{...} }
        public byte IntVal3 
        { 
            get 
            {
                return GetIntVal3(); 
            } 
            set
            {
                SetIntVal3(value);
            }
        }
        protected void virtual Init(arg1, arg2,...)
        {
             //Init properties
        }
        protected virtual byte GetIntVal3()
        {
             //Implementation
        }
        protected virtual void SetIntVal3(value)
        {
             //Implementation
        }
    }
    
    class MyCLass : BaseMyClass
    {
        public MyCLass(arg1, arg2, ...): base(arg1, arg2,...)
    }
    class AnotherMyCLass : BaseMyClass
    {
        public MyCLass(arg1, arg2, ...): base(arg1, arg2,...)
        protected override void Init(arg1, arg2,...)
        {
             //Init properties
        }
    }
