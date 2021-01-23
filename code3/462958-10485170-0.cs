    public interface IDeepClonable<T> where T : IDeepClonable<T>
    {
        void DeepClone(T other);
    }
    public class ClassA : IDeepClonable<ClassA> {
        void DeepClone(ClassA other) { ... }
    }
