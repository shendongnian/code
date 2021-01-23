    using System;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            var ad = AppDomain.CreateDomain("second");
            var t = (Test)ad.CreateInstanceAndUnwrap(typeof(Test).Assembly.FullName, typeof(Test).FullName);
            var b = new byte[] { 1 };
            t.Read(b);
            System.Diagnostics.Debug.Assert(b[0] == 2);
        }
    }
    
    class Test : MarshalByRefObject {
        public void Read([Out]byte[] arg) {
            arg[0] *= 2;
        }
    }
