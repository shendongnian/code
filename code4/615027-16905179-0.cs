    static void Main(string[] args)
    {
        Child child = new Child();
        Action parentPrint = (Action)Activator.CreateInstance(typeof(Action), child, typeof(Parent).GetMethod("Print").MethodHandle.GetFunctionPointer());
        parentPrint.Invoke();
    }
