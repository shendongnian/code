    public class A : List<publicClass>{}
    internal class B : List<internalClass>{}
    internal class C : List<publicClass>{}
    
    //not valid because D has wider accessibility than the close generic type List<internalClass>
    public class D : List<internalClass>{}
