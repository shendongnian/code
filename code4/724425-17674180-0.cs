    using System.Web.Services.Protocols;
    using System.Windows.Forms;
    using System;
    public static class ExtensionMethods
    {
        public static string ApplyServerURL(this SoapHttpClientProtocol service)
        {
            try
            {
                string name = service.GetType().Name;
                return string.Format("{0}{1}.svc", Settings.Instance.ServerAddress, name);
            }
            catch
            { return string.Empty; }
        }
    }
    
