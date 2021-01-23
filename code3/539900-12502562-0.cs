    public abstract class MyAbstractClass
    {
        protected class AccessMyFieldHelper
        {
            internal MyInternalClass this[MyAbstractClass mac]
            {
                get { return mac.myField; }
                set { mac.myField = value; }
            }
        }
        protected static readonly AccessMyFieldHelper AccessMyField = new AccessMyFieldHelper();
        
        private MyInternalClass myField;
    }
