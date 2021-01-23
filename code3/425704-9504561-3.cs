    public interface IClassA<ITB> { }
    public interface IClassB<ITA> { }
    public class ClassA<AT,BT> : IClassA<BT> where BT : IClassB<AT>
    {
        BT btvar;
    }
    public class ClassB<BT,AT> : IClassB<AT> where AT : IClassA<BT>
    {
        AT atvar;
    }
    public class ClassADerivedClosed : ClassA<ClassADerivedClosed, ClassBDerivedClosed> { }
    public class ClassBDerivedClosed : ClassB<ClassBDerivedClosed, ClassADerivedClosed> { }
