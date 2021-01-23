    public delegate void VoidFnDelegate();
    public value struct MyDLL
    {
        [DllImport("MyDll.dll")]
        static public void Display(VoidFnDelegate fn);
    }
    ...
    MyDll.Display(new VoidFnDelegate(YourCSharpFn));
