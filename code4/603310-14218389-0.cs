    public abstract class Base
    {
        public virtual T TestMethod<T>() where T : Base
        {
            // ...
        }
    }
    public class ClassA : Base
    {
        public override ClassA TestMethod<ClassA>()
        {
            return new ClassA();
        }
    }
