    // typeof obj: public class TestClassProxy : TestClass, IInterface1, IIterface2
    var obj = Proxy.Of<TestClass>(new CallHandler(), typeof(IInterface1), typeof(IInterface2));
    obj.MethodVoid();
    Console.WriteLine(obj.PublicSquare(3));
    Console.WriteLine(obj.MethodString());
