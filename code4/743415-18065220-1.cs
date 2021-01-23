    public class ClassC : ICustomCloneable<ClassC>
    {
        public ClassC ShallowCopy(ClassC obj) { /* Do special cloneing for ClassC */ }
        public ClassC DeepCopy(ClassC obj) { /* Do special cloning for ClassC */ }
    }
