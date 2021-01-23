    using System;
    
    namespace Foo {
        public class Test {
            public string how;
            internal Test(int arg) { how = "internal"; }
            public Test(long arg) { how = "public"; }
            public string ToString() { return how; }
        }
    }
