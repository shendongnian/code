    using System;
    using System.Net;
    using System.Net.Security;
    using System.Threading;
    using Microsoft.WindowsAzure.ServiceRuntime;
    
    namespace Website
    {
        public class WebRole : RoleEntryPoint
        {
            public override bool OnStart()
            {
                WarmUpWebsite("HttpIn");
                return base.OnStart();
            }
    
            public override void Run()
            {
                while (true)
                {
                    WarmUpWebsite("HttpIn");
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                }
            }
    
            public void WarmUpWebsite(string endpointName)
            {
                // Disable check for valid certificate. On som sites live HTTP request are redirected to HTTPS endpoint. And when running on staging SSL the certificate is invalid.
                RemoteCertificateValidationCallback allowAllCertificatesCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                ServicePointManager.ServerCertificateValidationCallback += allowAllCertificatesCallback;
                try
                {
                    RoleInstanceEndpoint endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints[endpointName];
    
                    string address = String.Format("{0}://{1}:{2}", endpoint.Protocol, endpoint.IPEndpoint.Address, endpoint.IPEndpoint.Port);
    
                    //This will cause Application_Start in global.asax to run
                    new WebClient().DownloadString(address);
                }
                catch (Exception)
                {
                    // intentionally swallow all exceptions here.
                }
                ServicePointManager.ServerCertificateValidationCallback -= allowAllCertificatesCallback;
            }
        }
    }
