    namespace Utils
    {
      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Net.Security;
      using System.Security.Cryptography.X509Certificates;
    
      /// <summary>
      /// Verifies that specific self signed root certificates are trusted.
      /// </summary>
      public class HttpClientHandler : System.Net.Http.HttpClientHandler
      {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientHandler"/> class.
        /// </summary>
        /// <param name="pemRootCerts">The PEM encoded root certificates to trust.</param>
        public HttpClientHandler(IEnumerable<string> pemRootCerts)
        {
          foreach (var pemRootCert in pemRootCerts)
          {
            var text = pemRootCert.Trim();
            text = text.Replace("-----BEGIN CERTIFICATE-----", string.Empty);
            text = text.Replace("-----END CERTIFICATE-----", string.Empty);
            this.rootCerts.Add(new X509Certificate2(Convert.FromBase64String(text)));
          }
    
          this.ServerCertificateCustomValidationCallback = this.VerifyServerCertificate;
        }
    
        private bool VerifyServerCertificate(
          object sender,
          X509Certificate certificate,
          X509Chain chain,
          SslPolicyErrors sslPolicyErrors)
        {
          // If the certificate is a valid, signed certificate, return true.
          if (sslPolicyErrors == SslPolicyErrors.None)
          {
            return true;
          }
    
          // If there are errors in the certificate chain, look at each error to determine the cause.
          if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) != 0)
          {
            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
    
            // add all your extra certificate chain
            foreach (var rootCert in this.rootCerts)
            {
              chain.ChainPolicy.ExtraStore.Add(rootCert);
            }
    
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            var isValid = chain.Build((X509Certificate2)certificate);
    
            var rootCertActual = chain.ChainElements[chain.ChainElements.Count - 1].Certificate;
            var rootCertExpected = this.rootCerts[this.rootCerts.Count - 1];
            isValid = isValid && rootCertActual.RawData.SequenceEqual(rootCertExpected.RawData);
    
            return isValid;
          }
    
          // In all other cases, return false.
          return false;
        }
    
        private readonly IList<X509Certificate2> rootCerts = new List<X509Certificate2>();
      }
    }
