    public class PemReaderB
    {
        public static RSACryptoServiceProvider GetRSAProviderFromPem(String pemstr)
        {
            Func<RsaKeyParameters, RSACryptoServiceProvider> MakePublicRCSP = (RsaKeyParameters rkp) =>
            {
                RSAParameters rsaParameters = DotNetUtilities.ToRSAParameters(rkp);
                CspParameters cspParameters = new CspParameters();
                cspParameters.KeyContainerName = "MyKeyContainer";
                RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParameters);
                rsaKey.ImportParameters(rsaParameters);
                return rsaKey;
            };
    
            Func<RsaPrivateCrtKeyParameters, RSACryptoServiceProvider> MakePrivateRCSP = (RsaPrivateCrtKeyParameters rkp) =>
            {
                RSAParameters rsaParameters = DotNetUtilities.ToRSAParameters(rkp);
                CspParameters cspParameters = new CspParameters();
                cspParameters.KeyContainerName = "MyKeyContainer";
                RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParameters);
                rsaKey.ImportParameters(rsaParameters);
                return rsaKey;
            };
    
            PemReader reader = new PemReader(new StringReader(pemstr));
            object kp = reader.ReadObject();
            
            // object holds "Private/Public" properties if it has a private key
            return (kp.GetType().GetProperty("Private") != null) ? MakePrivateRCSP((RsaPrivateCrtKeyParameters)(((AsymmetricCipherKeyPair)kp).Private)) : MakePublicRCSP((RsaKeyParameters)kp);
        }
    
        public static RSACryptoServiceProvider GetRSAProviderFromPemFile(String pemfile)
        {
            return GetRSAProviderFromPem(File.ReadAllText(pemfile).Trim());
        }
    }
