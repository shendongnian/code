        private static DateTime? _nextCertWarning;
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            if (error == SslPolicyErrors.None)
            {
                var cert2 = cert as X509Certificate2;
                if (cert2 != null)
                { 
                    // If cert expires within 2 days send an alert every 2 hours
                    if (cert2.NotAfter.AddDays(-2) < DateTime.Now)
                    {
                        if (_nextCertWarning == null || _nextCertWarning < DateTime.Now)
                        {
                            _nextCertWarning = DateTime.Now.AddHours(2);
                            ProwlUtil.StepReached("CERT EXPIRING WITHIN 2 DAYS " + cert, cert.GetCertHashString());   // this is my own function
                        }
                    }
                }
                return true;
            }
            else
            {
                switch (cert.GetCertHashString())
                {
                    // Machine certs - SELF SIGNED
                    case "066CF9CAD814DE2097D367F22D3A7E398B87C4D6":    
                        return true;
                    default:
                        ProwlUtil.StepReached("UNTRUSTED CERT " + cert, cert.GetCertHashString());
                        return false;
                }
            }
        }
