    public class AWrapper : A, IProxyWrapper
    {
        string IProxyWrapper.MyProperty 
        { 
            get { return base.MyProperty; }
            set { base.MyProperty = value; }
        }
    }
