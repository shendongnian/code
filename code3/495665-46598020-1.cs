    public class PemReaderB
    {
        public static RSACryptoServiceProvider GetRSAProviderFromPem(String pemstr)
        {
            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = "MyKeyContainer";
            RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParameters);
            Func<RSACryptoServiceProvider, RsaKeyParameters, RSACryptoServiceProvider> MakePublicRCSP = (RSACryptoServiceProvider rcsp, RsaKeyParameters rkp) =>
            {
                RSAParameters rsaParameters = DotNetUtilities.ToRSAParameters(rkp);
                rcsp.ImportParameters(rsaParameters);
                return rsaKey;
            };
            Func<RSACryptoServiceProvider, RsaPrivateCrtKeyParameters, RSACryptoServiceProvider> MakePrivateRCSP = (RSACryptoServiceProvider rcsp, RsaPrivateCrtKeyParameters rkp) =>
            {
                RSAParameters rsaParameters = DotNetUtilities.ToRSAParameters(rkp);
                rcsp.ImportParameters(rsaParameters);
                return rsaKey;
            };
            PemReader reader = new PemReader(new StringReader(pemstr));
            object kp = reader.ReadObject();
            // If object has Private/Public property, we have a Private PEM
            return (kp.GetType().GetProperty("Private") != null) ? MakePrivateRCSP(rsaKey, (RsaPrivateCrtKeyParameters)(((AsymmetricCipherKeyPair)kp).Private)) : MakePublicRCSP(rsaKey, (RsaKeyParameters)kp);
        }
    
        public static RSACryptoServiceProvider GetRSAProviderFromPemFile(String pemfile)
        {
            return GetRSAProviderFromPem(File.ReadAllText(pemfile).Trim());
        }
    }
