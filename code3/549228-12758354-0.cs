    namespace TerminatorConsole2.Utils
    {
        public class Constants
        {
            public const string MANAGEMENT_CONSOLE_ADDRESS =
                Commons.Constants.USE_EXTRA_WCF_INSTANCE ?
                    "net.pipe://localhost/xxx" :
                    "net.pipe://localhost";
        }
     }
