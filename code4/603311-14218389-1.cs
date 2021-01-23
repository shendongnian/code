    public abstract class Base
    {
        public abstract T AbstractTestMethod<T>() where T : Base;
        public virtual T VirtualTestMethod<T>() where T : Base, new()
        {
            return new T();
        }
    }
    public class ClassA : Base
    {
        public override ClassA AbstractTestMethod<ClassA>()
        {
            return new ClassA();
        }
        public override ClassA VirtualTestMethod<ClassA>()
        {
            return new ClassA();
        }
    }
