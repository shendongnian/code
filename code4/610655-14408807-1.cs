    class MyClass
    {
        public void Fn100() {...}
        public void Fn101() {...}
        public void Fn102() {...}
    }
    
    public class Program
    {
        public static void Main()
        {
            ExecFnNumber("100");
            ExecFnNumber("105");
        }
        public static void ExecFnNumber(string num)
        {
            Type myType = Type.GetType("MyClass");
            // create an instance
            ConstructorInfo constructor = myType.GetConstructor(Type.EmptyTypes);
            object myTypeObject = myType.Invoke(new object[]{});
            // call method without params
            MethodInfo magicMethod = myType.GetMethod("Fn" + num);
            object magicValue = magicMethod.Invoke(myTypeObject, new object[]{});
        }
    }
