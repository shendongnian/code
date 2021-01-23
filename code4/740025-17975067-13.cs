        public class ClassB : ClassC {
            //...
        }
        public class ClassA : ClassB {
            public ClassA(){
               ((ClassC)this).MemberOfClassC ... ;//There might be some member in ClassC
               //which is overridden in ClassA or ClassB, casting to ClassC can help we invoke the original member instead of the overridden one.
            }
        }
