    namespace ClassLibrary7
    {
        public class Parent
        {
            public virtual string Method()
            {
                return "Parent";
            }
        }
    
        public class Child : Parent
        {
            public override string Method()
            {
                return base.Method() + "Child";
            } 
        }
    }
