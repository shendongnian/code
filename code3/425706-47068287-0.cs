    public class ClassA<BT, AT> :
        where BT : ClassB<AT, BT>
        where AT : ClassA<BT, AT>
    {
        BT btvar;
    }
    public class ClassB<AT, BT> :
        where BT : ClassB<AT, BT>
        where AT : ClassA<BT, AT>   
    {
        AT atvar;
    }
