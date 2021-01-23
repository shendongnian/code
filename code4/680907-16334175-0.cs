    public class MyClass
    {
        private OtherClass _someProperty;
        public OtherClass SomeProperty 
        {
            get
            { 
                 if (this._someProperty == null) this._someProperty = new OtherClass(this);
                 return this._someProperty;
            }
        }
    }
    
    public class OtherClass
    {
        private MyClass _parent;
        public OtherClass(MyClass parent)
        {
            this._parent = parent;
        }
    }
