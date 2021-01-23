    public class Foo {
        public void Main() {
            what();
        }
        public void what() {
            Bar.GetCallersType();
        }
        public static class Bar {
            public static void GetCallersType() {
                StackTrace stackTrace = new StackTrace();
                var type = stackTrace.GetFrame(1).GetMethod().DeclaringType;
                //this will provide you typeof(Foo);
            }
        }
    }
