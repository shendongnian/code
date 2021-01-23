    using MyApplication.Helpers.Encoding; // !!!
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test1();
                Test2();
            }
    
            static void Test1()
            {
                string textEncoded = System.Text.Encoding.UTF8.EncodeBase64("test1...");
                System.Diagnostics.Debug.Assert(textEncoded == "dGVzdDEuLi4=");
                string textDecoded = System.Text.Encoding.UTF8.DecodeBase64(textEncoded);
                System.Diagnostics.Debug.Assert(textDecoded == "test1...");
            }
            static void Test2()
            {
                string textEncoded = System.Text.Encoding.UTF8.EncodeBase64(null);
                System.Diagnostics.Debug.Assert(textEncoded == null);
                string textDecoded = System.Text.Encoding.UTF8.DecodeBase64(textEncoded);
                System.Diagnostics.Debug.Assert(textDecoded == null);
            }
        }
    }
