    namespace cSharpRiJHarn
    {
        [Guid("ED1483A3-000A-41f5-B1BC-5235F5897872")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComVisible(true)]
        public interface IRijndaelLink
        {
            string encrypt(string s);
            string decrypt(string s);
        }
    
        [Guid("7C13A8C6-4230-445f-8C77-0CA5EDECDCB5")]
        [ComVisible(true)]
        public class RijndaelLink : IRijndaelLink
        {
            public string encrypt(string s)
            {
                return Rijndael.EncryptString(s); 
            }
    
            public string decrypt(string s)
            {
                return Rijndael.DecryptString(s); 
            }
        }
    }
