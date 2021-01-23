    abstract class AbstractClassOne
    {
        public abstract void ShowMessage();
        public abstract void DisplayName();
    }
    
    Interface IClassTwo
    {
        void ShowMessage();
        void DisplayPlace();
    }
    
    class DerivedClass : AbstractClassOne, IClassTwo
    {
    
    }
