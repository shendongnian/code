    public class A 
    {
        public string CString { get { return "a"; } }
    }
    
    public class B : A
    {
        public new string CString { get { return "b"; }}
    }
