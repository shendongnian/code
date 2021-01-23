    string str = @"D:\MyDLL.dll";
    str = Path.GetFullPath(str);
    Assembly assembly = Assembly.LoadFile(str);
    string args = {"a",	"b"}; //command line args that you need to pass
    MethodInfo publicStaticVoidMain = assembly.EntryPoint;
    publicStaticVoidMain.Invoke(null, args);
