    using System.Runtime.CompilerServices;
    void myMethod()
    {
        ShowMethodName();
    }
    void ShowMethodName([CallerMemberName]string methodName = "")
    {
        MessageBox(methodName);
    }
