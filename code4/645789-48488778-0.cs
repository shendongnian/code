    public static class MyStaticData
    {
        public static const string Class1String = "MyString1";
        public static const int Class1Int = 1;
        public static const string Class2String = "MyString2";
        public static const int Class2Int = 2;
        // etc...
    }
    
    public abstract class MyBaseClass
    {
        public abstract string MyPseudoVirtualStringProperty { get; }
        public abstract int MyPseudoVirtualIntProperty { get; }
    }
    public class MyDerivedClass1 : My BaseClass
    {
        public override string MyPseudoVirtualStringProperty { get { return MyStaticData.Class1String; } }
        public override int MyPseudoVirtualIntProperty { get { return MyStaticData.Class1Int } }
    }
    public class MyDerivedClass2 : My BaseClass
    {
        public override string MyPseudoVirtualStringProperty { get { return MyStaticData.Class2String; } }
        public override int MyPseudoVirtualIntProperty { get { return MyStaticData.Class2Int } }
    }
