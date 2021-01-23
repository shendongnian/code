    > add-type @"
    namespace TestStructs {
        public struct Inner {
            public int i;
        };
        public class Outer {
            public Inner i;
        }
    }
    "@
    $s = new-object TestStructs.Outer
