    void Main()
    {
        CallUserFuncArray("UserQuery+Foo", "Bar", "One", "Two");
    }
    
    // Define other methods and classes here
    public class Foo
    {
        public static void Bar(string a, string b){}
    }
    
    public void CallUserFuncArray(string className, string methodName, params object[] args)
    {
        Type.GetType(className).GetMethod(methodName).Invoke(null, args);
    }
