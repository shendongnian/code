    public abstract class BaseClass
    {
        protected Parent field;
    
        public BaseClass(Parent someField)
        {
            this.field = someField
            if (someField is Child1)
                this.Property1 = ((Child1)someField).Foo();
        }
    
        public Int32 Property1
        {
            get { return field.Child1Property; }
            set { field.Child1Property = value; }
        }
    }
