    using System;
    using System.IO;
    using Microsoft.Web.FtpServer;
    using System.Diagnostics;
    using System.Diagnostics.Eventing;
    namespace FtpLogging
    {
        public class FtpLogDemo : BaseProvider,
            IFtpLogProvider
        {
            void IFtpLogProvider.Log(FtpLogEntry loggingParameters)
            {
             .......
