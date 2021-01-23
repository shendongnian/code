    [Guid("69432320-04B6-3233-928F-FD8583232C880")]
    public interface MyInterface
    {
       [DispId(1)]
       void Method1 (string name);
    }
    
    MyInterface myInterface = (MyInterface )new ConcreateClassImplementingInterface ();
