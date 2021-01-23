    private static void GenerateKeys(out string forPubKey, out string forPrivKey)
            {
                GenerateKeys(out forPubKey, out forPrivKey, 2048, 65537, 80);
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="forPubKey"></param>
            /// <param name="forPrivKey"></param>
            /// <param name="keyStrength">1024, 2048,4096</param>
            /// <param name="exponent">Typically a fermat number 3, 5, 17, 257, 65537, 4294967297, 18446744073709551617,</param>
            /// <param name="certaninty">Should be 80 or higher depending on Key strength number (exponent)</param>
            private static void GenerateKeys(out string forPubKey, out string forPrivKey, int keyStrength, int exponent, int certaninty)
            {
                // Create key
                RsaKeyPairGenerator generator = new RsaKeyPairGenerator();
    
                /*
                 * This value should be a Fermat number. 0x10001 (F4) is current recommended value. 3 (F1) is known to be safe also.
                 * 3, 5, 17, 257, 65537, 4294967297, 18446744073709551617,
                 * 
                 * Practically speaking, Windows does not tolerate public exponents which do not fit in a 32-bit unsigned integer. Using e=3 or e=65537 works "everywhere". 
                 */
                BigInteger exponentBigInt = new BigInteger(exponent.ToString());
    
                var param = new RsaKeyGenerationParameters(
                    exponentBigInt, // new BigInteger("10001", 16)  publicExponent
                    new SecureRandom(),  // SecureRandom.getInstance("SHA1PRNG"),//prng
                    keyStrength, //strength
                    certaninty);//certainty
                generator.Init(param);
                AsymmetricCipherKeyPair keyPair = generator.GenerateKeyPair();
    
                // Save to export format
                SubjectPublicKeyInfo info = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(keyPair.Public);
                byte[] ret = info.GetEncoded();
                forPubKey = Convert.ToBase64String(ret);
    
                //  EncryptedPrivateKeyInfo asdf = EncryptedPrivateKeyInfoFactory.CreateEncryptedPrivateKeyInfo(
                //    DerObjectIdentifier.Ber,,,keyPair.Private);
    
                //// demonstration: how to serialise option 1
                //TextWriter textWriter = new StringWriter();
                //PemWriter pemWriter = new PemWriter(textWriter);
                //pemWriter.WriteObject(keyPair);
                //pemWriter.Writer.Flush();
                //string ret2 = textWriter.ToString();
    
                //// demonstration: how to serialise option 1
                //TextReader tr = new StringReader(ret2);
                //PemReader read = new PemReader(tr);
                //AsymmetricCipherKeyPair something = (AsymmetricCipherKeyPair)read.ReadObject();
    
                //// demonstration: how to serialise option 2 (don't know how to deserailize)
                //PrivateKeyInfo pKinfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(keyPair.Private);
                //byte[] privRet = pKinfo.GetEncoded();
                //string forPrivKey2Test = Convert.ToBase64String(privRet);
    
    
    
                PrivateKeyInfo pKinfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(keyPair.Private);
                byte[] privRet = pKinfo.GetEncoded();
                string forPrivKey2Test = Convert.ToBase64String(privRet);
    
                forPrivKey = forPrivKey2Test;
            }
