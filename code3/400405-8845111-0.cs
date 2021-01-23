    using System;
    using System.IO;
    using System.Text;
    using Org.BouncyCastle.Asn1;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.Utilities.Encoders;
    
    namespace API.Crypto
    {
        public class RsaSha1Signing
        {
            private RsaKeyParameters MakeKey(String modulusHexString, String exponentHexString, bool isPrivateKey)
            {
                var modulus = new Org.BouncyCastle.Math.BigInteger(modulusHexString, 16);
                var exponent = new Org.BouncyCastle.Math.BigInteger(exponentHexString, 16);
    
                return new RsaKeyParameters(isPrivateKey, modulus, exponent);
            }
    
            public String Sign(String data, String privateModulusHexString, String privateExponentHexString)
            {
                /* Make the key */
                RsaKeyParameters key = MakeKey(privateModulusHexString, privateExponentHexString, true);
    
                /* Init alg */
                ISigner sig = SignerUtilities.GetSigner("SHA1withRSA");
    
                /* Populate key */
                sig.Init(true, key);
                
                /* Get the bytes to be signed from the string */
                var bytes = Encoding.UTF8.GetBytes(data);
    
                /* Calc the signature */
                sig.BlockUpdate(bytes, 0, bytes.Length);
                byte[] signature = sig.GenerateSignature();
                
                /* Base 64 encode the sig so its 8-bit clean */
                var signedString = Convert.ToBase64String(signature);
    
                return signedString;
            }
    
            public bool Verify(String data, String expectedSignature, String publicModulusHexString, String publicExponentHexString)
            {
                /* Make the key */
                RsaKeyParameters key = MakeKey(publicModulusHexString, publicExponentHexString, false);
    
                /* Init alg */
                ISigner signer = SignerUtilities.GetSigner("SHA1withRSA");
    
                /* Populate key */
                signer.Init(false, key);
    
                /* Get the signature into bytes */
                var expectedSig = Convert.FromBase64String(expectedSignature);
    
                /* Get the bytes to be signed from the string */
                var msgBytes = Encoding.UTF8.GetBytes(data);
    
                /* Calculate the signature and see if it matches */
                signer.BlockUpdate(msgBytes, 0, msgBytes.Length);
                return signer.VerifySignature(expectedSig);
            }
        }
    }
