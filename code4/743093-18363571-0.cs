        /// <summary>
        /// Gets the certificate for protection key id.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="protectionKeyId">The protection key id.</param>
        /// <returns>The content key.</returns>
        internal static X509Certificate2 GetCertificateForProtectionKeyId(DataServiceContext dataContext, string protectionKeyId)
        {
            // First check to see if we have the cert in our store already.
            X509Certificate2 certToUse = EncryptionUtils.GetCertificateFromStore(protectionKeyId);
 
            if ((certToUse == null) && (dataContext != null))
            {
                // If not, download it from Nimbus to use.
                Uri uriGetProtectionKey = new Uri(string.Format(CultureInfo.InvariantCulture, "/GetProtectionKey?protectionKeyId='{0}'", protectionKeyId), UriKind.Relative);
                IEnumerable<string> results2 = dataContext.Execute<string>(uriGetProtectionKey);
                string certString = results2.Single();
 
                byte[] certBytes = Convert.FromBase64String(certString);
                certToUse = new X509Certificate2(certBytes);
 
                // Finally save it for next time.
                EncryptionUtils.SaveCertificateToStore(certToUse);
            }
 
            return certToUse;
        }
 
 
