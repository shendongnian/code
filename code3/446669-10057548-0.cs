    namespace TheDll
    {
        public class SomeClass
        {
            public virtual void TheMethod()
            { }
        }
    }
    namespace TheProject
    {
        public class DerivedClass : SomeClass
        {
            public override void TheMethod()
            { }
        }
    }
