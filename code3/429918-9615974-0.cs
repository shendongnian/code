    public abstract class Parent
    {
        public void TheSingleMethod()
        {
            CommonFunctionality();
            
            InternalDo();
        }
    
        protected abstract void InternalDo();
        private void CommonFunctionality()
        {
            // Common functionality goes here.
        }
    }
    public class Derived : Parent
    {
        protected override void InternalDo()
        {
            // Additional code of child goes here.
        }
    }
