    public class SomeDerivedClass : NodeRef
    {
        // ...
    }
    static void Main(string[] args)
    {
        var nodeRef = new NodeRef();
        var newNodeRef = (SomeDerivedClass) nodeRef;
    }
