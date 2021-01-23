    using System.Runtime.CompilerServices;
    void myMethod()
    {
        ShowMethodName();
    }
    void ShowMethodName([CallerMemberName]methodName)
    {
        MessageBox(methodName);
    }
