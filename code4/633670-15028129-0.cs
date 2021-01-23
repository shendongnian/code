    internal class PermissiveCertificatePolicy
    {
        private string _subjectName;
        private static PermissiveCertificatePolicy _currentPolicy;
        public PermissiveCertificatePolicy(string subjectName)
        {
            _subjectName = subjectName;
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertValidate;
        }
        public static void Enact(string subjectName)
        {
            _currentPolicy = new PermissiveCertificatePolicy(subjectName);
        }
        private bool RemoteCertValidate(object sender, X509Certificate cert,
            X509Chain chain, SslPolicyErrors error)
        {
            return cert.Subject == _subjectName;
        }
    }
