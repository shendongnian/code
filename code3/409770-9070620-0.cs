    namespace DeviceManagement.Register
    {
        public class Register
        {
            public RegisterType Type { get; private set; }
            public string Foo { get; private set; }
            public string Bar { get; private set;  }
    
            public Register(RegisterType type, string foo, string bar)
            {
                Type = type;
                Foo = foo;
                Bar = bar;
            }
        }
    
        public enum RegisterType
        {
            reg1 = 0x01,
            reg2 = 0x02 //and so on   
        }
    
        public static class RegisterFactory
        {
            private static readonly Dictionary<RegisterType, Register> _dictionary = new Dictionary<RegisterType, Register>
                                                                         {
                                                                             { RegisterType.reg1, new Register(RegisterType.reg1, "foo", "bar") },
                                                                             { RegisterType.reg2, new Register(RegisterType.reg2, "foo2", "bar2") }
                                                                         };
    
            public static Register GetRegister(RegisterType type)
            {
                return _dictionary[type];
            }
        }
    }
