    public class Class1
    {
        public enum class1: {classA, classB}
        public static Class1 Make(class1 which)
        {
            switch (which)
            {
                 case classA: return new ClassA();
                 case classB: return new ClassB();
                 default: return null;
            }
        }
     }
     public class ClassA: Class1 {}
     public class ClassA: Class1 {}
