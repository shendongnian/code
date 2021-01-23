    public class MyParametersClass
    {
        public string s { get; set; }
        public int i { get; set; }
        public MyType t { get;set; }
    
        public MyParametersClass()
        {
            // set defaults
            s = null;
            i = 0;
            MyType = null;
        }
    }
    
    public void MyMethod(MyParametersClass c)
    { 
        /* body */ 
    }
 
