        public X509Certificate2 CreateSelfSignedCert(string subject,string password,DateTime expDate)
        {
            // create DN for subject and issuer
            var dn = new CX500DistinguishedName();
           // dn.Encode("CN=" + subject, X500NameFlags.XCN_CERT_NAME_STR_NONE);
            dn.Encode(subject, X500NameFlags.XCN_CERT_NAME_STR_NONE);
            
            // create a new private key for the certificate
            CX509PrivateKey privateKey = new CX509PrivateKey();
            privateKey.ProviderName = "Microsoft Base Cryptographic Provider v1.0";
            privateKey.MachineContext = true;
            privateKey.Length = 2048;
            privateKey.KeySpec = X509KeySpec.XCN_AT_SIGNATURE; // use is not limited
            privateKey.ExportPolicy
                = X509PrivateKeyExportFlags.XCN_NCRYPT_ALLOW_PLAINTEXT_EXPORT_FLAG;
            privateKey.Create();
            // Use Sha256 hashing algorithm
            var hashobj = new CObjectId();
            hashobj.InitializeFromAlgorithmName(
                ObjectIdGroupId.XCN_CRYPT_HASH_ALG_OID_GROUP_ID,
                ObjectIdPublicKeyFlags.XCN_CRYPT_OID_INFO_PUBKEY_ANY,
                AlgorithmFlags.AlgorithmFlagsNone,
                "SHA256");
            // Create the self signing request
            var cert = new CX509CertificateRequestCertificate();
            cert.InitializeFromPrivateKey(
                X509CertificateEnrollmentContext.ContextMachine,
                privateKey,
                string.Empty);
            cert.Subject = dn;
            cert.Issuer = dn; // the issuer and the subject are the same
            cert.NotBefore = DateTime.Now;
            cert.NotAfter = expDate;
            cert.HashAlgorithm = hashobj;
            // extensions 
            CX509ExtensionKeyUsage ku = new CX509ExtensionKeyUsage();
            ku.InitializeEncode(CERTENROLLLib.X509KeyUsageFlags.XCN_CERT_KEY_CERT_SIGN_KEY_USAGE | CERTENROLLLib.X509KeyUsageFlags.XCN_CERT_DIGITAL_SIGNATURE_KEY_USAGE);
            ku.Critical = true;
            cert.X509Extensions.Add((CX509Extension)ku);
            CX509ExtensionBasicConstraints bc = new CX509ExtensionBasicConstraints();
            bc.InitializeEncode(true,0);
            bc.Critical = false;
            cert.X509Extensions.Add((CX509Extension)bc);
            // Add the certificate policy.
            CObjectId cpOid = new CObjectId();
            cpOid.InitializeFromValue("some oid");
            CCertificatePolicy cp = new CCertificatePolicy();
            CPolicyQualifier Qualifier = new CPolicyQualifier();
            Qualifier.InitializeEncode("Policy Notice", PolicyQualifierType.PolicyQualifierTypeUserNotice);
            cp.Initialize(cpOid);
            cp.PolicyQualifiers.Add(Qualifier);
            CCertificatePolicies cps = new CCertificatePolicies();
            cps.Add(cp);
            CX509ExtensionCertificatePolicies cpExt = new CX509ExtensionCertificatePolicies();
            cpExt.InitializeEncode(cps);
            cert.X509Extensions.Add((CX509Extension)cpExt);
            // Do the final enrollment process
            var enroll = new CX509Enrollment();
            enroll.InitializeFromRequest(cert); // load the certificate
            string csr = enroll.CreateRequest(); // Output the request in base64
            // and install it back as the response
            enroll.InstallResponse(InstallResponseRestrictionFlags.AllowUntrustedCertificate,
                csr, EncodingType.XCN_CRYPT_STRING_BASE64, ""); // no password
            // output a base64 encoded PKCS#12 so we can import it back to the .Net security classes
            var base64encoded = enroll.CreatePFX( "", PFXExportOptions.PFXExportChainWithRoot);
            
            // instantiate the target class with the PKCS#12 data (and the empty password)
            return new System.Security.Cryptography.X509Certificates.X509Certificate2(
                System.Convert.FromBase64String(base64encoded), "",
                // mark the private key as exportable
                System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.Exportable
            );
        }
