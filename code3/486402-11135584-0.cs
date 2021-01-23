    private static IBufferedCipher GetKeyCipher(
                PublicKeyAlgorithmTag algorithm)
            {
                try
                {
                    switch (algorithm)
                    {
                        case PublicKeyAlgorithmTag.RsaEncrypt:
                        case PublicKeyAlgorithmTag.RsaGeneral:
                            return CipherUtilities.GetCipher("RSA//PKCS1Padding");
                        case PublicKeyAlgorithmTag.ElGamalEncrypt:
                        case PublicKeyAlgorithmTag.ElGamalGeneral:
                            return CipherUtilities.GetCipher("ElGamal/ECB/PKCS1Padding");
                        default:
                            throw new PgpException("unknown asymmetric algorithm: " + algorithm);
                    }
                }
                catch (PgpException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new PgpException("Exception creating cipher", e);
                }
            }
