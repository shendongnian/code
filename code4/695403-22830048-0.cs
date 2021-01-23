    public interface INativeCrypto : INativeImport
    {
        [ImportFunction("mynative.dll"]
        int NativeMethod();
    }
   
    [TestClass]
    public class UnitTest1
    {
        public void TestMethod1()
        {
            INativeCrypto impl = NativeImport.Create<INativeCrypto>("");
            // Use methods in impl
            int i = impl.NativeMethod();
            //...
        }
    }
