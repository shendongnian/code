    namespace ourApplication
    {
        public static class Global
        {
            public static readonly Entity Vehicle = 1;
            public static readonly Entity Animal = 2;
            public static readonly Entity Foo = 3; //etc
        }
    
        public class Vehicle : Framework
        {
            public override Entity RecordType { get { return  Global.Vehicle; } }
        }
    }
