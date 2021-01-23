    public interface ICustomCloneable<T>
    {
        T ShallowCopy();
        T DeepCopy();
    }
    public abstract class CustomCloneable<T> ICustomCloneable<T> where T : class
    {
        public T ShallowCopy() { return ShallowCopy(this); }
        public T DeepCopy() { return DeepCopy(this); }
        // static helpers
        public static object ShallowCopy(T obj) { /* boilerplate implementation */ }
        public static object DeepCopy(T obj) { /* boilerplate implementation */ }
    }
    public class ClassA : CustomCloneable<ClassA> { /* Use boilerplate functionality */ }
    public class ClassB : SomeOtherClass, ICustomCloneable<ClassB>
    {
        // implement ICustomCloneable using static helpers
        public ClassB ShallowCopy() { return CustomCloneable<ClassB>.ShallowCopy(this); }
        public ClassB DeepCopy() { return CustomCloneable<ClassB>.DeepCopy(this); }
    }
