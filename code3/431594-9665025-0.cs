    using System;
    using System.IO;
    using Microsoft.Web.FtpServer;
    
    namespace FtpLogging
    {
        public class FtpLogDemo : BaseProvider,
            IFtpLogProvider
        {
            void IFtpLogProvider.Log(FtpLogEntry loggingParameters)
            {
             .......
