    // The class library
    using System;
    namespace MyClassLibrary {
        public class X {
            public const Int16 protocol_version = 1;
            public Int16 ProtocolVersion { get { return protocol_version; } }
        }
    }
    // The program
    using System;
    using MyClassLibrary;
    class Program {
        static void Main(string[] args) {
            X x = new X();
            Console.WriteLine("Constant : {0}", X.protocol_version);
            Console.WriteLine("Getter: {0}", x.ProtocolVersion);
        }
    }
