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
            // can probably optimize by not instantiating
            // myType, myTypeObject every time.
            Type myType = typeof(MyClass);
            // create an instance
            var myTypeObject = new MyClass();
            // call method without params
            MethodInfo method = myType.GetMethod("Fn" + num);
            method.Invoke(myTypeObject, new object[]{});
        }
    }
