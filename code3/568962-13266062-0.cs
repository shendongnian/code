    public class LogIT
    {
        public string strMessage = string.Empty;
        public string strClassName = string.Empty;
        public string strMethodName = string.Empty; 
        public void LogStackTrace()
        {
            strMethodName = new StackFrame(1).GetMethod().Name;
            strClassName = new StackFrame(1).GetMethod().DeclaringType.Name;
        }
    }
    public class Product : LogIT
    {
        public Product()
        {
        }
        public void GetProduct()
        {
            base.LogStackTrace();
        }
        public void AddEditProduct()
        {
           
        }
    }
