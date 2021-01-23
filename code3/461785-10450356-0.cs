    class Program
    {
        static void Main(string[] args)
        {
            Action whatToDo = MyLambda; // Method group conversion
            whatToDo();
        }
        static void MyLambda()
        {
            var member = (MemberInfo)(MethodBase.GetCurrentMethod());
            Thread.Sleep(0); //whatever, need something to put a breakpoint on
        }
    }
