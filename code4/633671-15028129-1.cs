    namespace WcfClient
    {
        internal class Program
        {
            private const string RCertName = "CN=WMSvc-WIN-R0NU6K5QG87";
            private static void Main(string[] args)
            {
                PermissiveCertificatePolicy.Enact(RCertName);
                using (MyClient proxy = new MyClient("Ws2007HttpBinding_IHistory"))
                {
                    ...
                }
            }
        }
    }
