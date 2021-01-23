    public class ClassC : ICustomCloneable<ClassC>
    {
        public ClassC ShallowCopy() { /* Do special cloning for ClassC */ }
        public ClassC DeepCopy() { /* Do special cloning for ClassC */ }
    }
