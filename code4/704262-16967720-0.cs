    using System.Runtime.CompilerServices;
    void Main()
    {
        var myObj = new MyClass();
        myObj.Method1("foo", 1);
    }
    
    public class MyClass
    {
        public void Method1(object someArgument, object someOtherArgument,
                     [CallerMemberName] string callerMemberName = null,
                     [CallerFilePath] string callerFilePath = null,
                     [CallerLineNumber] int callerLineNumber = 0)
        {
            Console.WriteLine(
                 string.Format("Called with {0}, {1} from method {2} in file {3} at line number {4}",
                    someArgument, someOtherArgument, 
                    callerMemberName, callerFilePath, callerLineNumber));
        }
    }
