        public static void rsaPlayground()
        {
            byte[] data = new byte[] { 1, 2, 3, 4, 5 };
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();//make a new csp with a new keypair
            var pub_key = csp.ExportParameters(false); // export public key
            var priv_key = csp.ExportParameters(true); // export private key
            var encData = csp.Encrypt(data, false); // encrypt with PKCS#1_V1.5 Padding
            var decBytes = MyRSAImpl.plainDecryptPriv(encData, priv_key); //decrypt with own BigInteger based implementation
            var decData = decBytes.SkipWhile(x => x != 0).Skip(1).ToArray();//strip PKCS#1_V1.5 padding
        }
        public class MyRSAImpl 
        {
            private static byte[] rsaOperation(byte[] data, BigInteger exp, BigInteger mod)
            {
                BigInteger bData = new BigInteger(
                    data    //our data block
                    .Reverse()  //BigInteger has another byte order
                    .Concat(new byte[] { 0 }) // append 0 so we are allways handling positive numbers
                    .ToArray() // constructor wants an array
                );
                return 
                    BigInteger.ModPow(bData, exp, mod) // the RSA operation itself
                    .ToByteArray() //make bytes from BigInteger
                    .Reverse() // back to "normal" byte order
                    .ToArray(); // return as byte array
                /*
                 * 
                 * A few words on Padding:
                 * 
                 * you will want to strip padding after decryption or apply before encryption 
                 * 
                 */
            }
            public static byte[] plainEncryptPriv(byte[] data, RSAParameters key) 
            {
                MyRSAParams myKey = MyRSAParams.fromRSAParameters(key);
                return rsaOperation(data, myKey.privExponent, myKey.Modulus);
            }
            public static byte[] plainEncryptPub(byte[] data, RSAParameters key)
            {
                MyRSAParams myKey = MyRSAParams.fromRSAParameters(key);
                return rsaOperation(data, myKey.pubExponent, myKey.Modulus);
            }
            public static byte[] plainDecryptPriv(byte[] data, RSAParameters key)
            {
                MyRSAParams myKey = MyRSAParams.fromRSAParameters(key);
                return rsaOperation(data, myKey.privExponent, myKey.Modulus);
            }
            public static byte[] plainDecryptPub(byte[] data, RSAParameters key)
            {
                MyRSAParams myKey = MyRSAParams.fromRSAParameters(key);
                return rsaOperation(data, myKey.pubExponent, myKey.Modulus);
            }
            
        }
        public class MyRSAParams
        {
            public static MyRSAParams fromRSAParameters(RSAParameters key)
            {
                var ret = new MyRSAParams();
                ret.Modulus = new BigInteger(key.Modulus.Reverse().Concat(new byte[] { 0 }).ToArray());
                ret.privExponent = new BigInteger(key.D.Reverse().Concat(new byte[] { 0 }).ToArray());
                ret.pubExponent = new BigInteger(key.Exponent.Reverse().Concat(new byte[] { 0 }).ToArray());
                return ret;
            }
            public BigInteger Modulus;
            public BigInteger privExponent;
            public BigInteger pubExponent;
        }
