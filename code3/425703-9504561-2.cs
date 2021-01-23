    public interface IClassA { }
    public class ClassA<BT> : IClassA where BT : ClassB<IClassA>
    {
        BT btvar;
    }
    public class ClassB<AT>  where AT : IClassA
    {
        AT atvar;
    }
