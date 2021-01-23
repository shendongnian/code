    using System.Runtime.CompilerServices;
    public class Foo {
        public void Main() {
            what();
        }
        public void what() {
            Bar.GetCallersType();
        }
        public static class Bar {
            [MethodImpl(MethodImplOptions.NoInlining)]  //This will prevent inlining by the complier.
            public static void GetCallersType() {
                StackTrace stackTrace = new StackTrace(1, false); //Captures 1 frame, false for not collecting information about the file
                var type = stackTrace.GetFrame(1).GetMethod().DeclaringType;
                //this will provide you typeof(Foo);
            }
        }
    }
