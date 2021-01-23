    public abstract class AbstractClass
    {
        // Note that this protected since consumers won't call it directly
        protected abstract void AbstractMethod();
        // Instead, consumers will use this method which calls CommonCode
        // before the abstract method.
        public void AbstractMethodWrapper()
        {
            CommonCode();
            AbstractMethod();
        }
        public void CommonCode()
        {
            //do something
        }
    }
    public class ChildClass : AbstractClass
    {
        protected override void AbstractMethod()
        {
            // The wrapper method in the base handles calling common code
            //do something
        }
    }
