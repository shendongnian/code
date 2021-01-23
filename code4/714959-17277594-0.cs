    class ClassBase
    {
        public static string ClassField;
    
        public virtual void MethodOne()
        {
            CommonMethod();
        }
        
        public virtual void CommonMethod()
        {
            ClassField = "1";
        }
    }
    
    class ClassOne : ClassBase
    {
    }
    
    class ClassTwo : ClassBase
    {
        public void CommonMethod(string a, string b)
        {
            string localVariable;
            base.CommonMethod();
        }
    }
