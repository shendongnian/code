            private static PgpPrivateKey GetPrivateKey(string privateKeyPath)
        {
            using (Stream keyIn = File.OpenRead(privateKeyPath))
            using (Stream inputStream = PgpUtilities.GetDecoderStream(keyIn))
            {
                PgpSecretKeyRingBundle secretKeyRingBundle = new PgpSecretKeyRingBundle(inputStream);
                PgpSecretKey key = null;
                foreach (PgpSecretKeyRing kRing in secretKeyRingBundle.GetKeyRings())
                {
                    foreach (PgpSecretKey secretKey in kRing.GetSecretKeys())
                    {
                        PgpPrivateKey privKey = secretKey.ExtractPrivateKey("1234567890".ToCharArray());
                        if (privKey.Key.GetType() ==
                            typeof (Org.BouncyCastle.Crypto.Parameters.ElGamalPrivateKeyParameters))
                            //Org.BouncyCastle.Crypto.Parameters.ElGamalPrivateKeyParameters
                        {
                            return privKey;
                        }
                    }
                }
            }
            
            return null;
        }
        public static void Decrypt(Stream input, string outputpath, String privateKeyPath)
        {
            input = PgpUtilities.GetDecoderStream(input);
            try
            {
                PgpObjectFactory pgpObjF = new PgpObjectFactory(input);
                PgpEncryptedDataList enc;
                PgpObject obj = pgpObjF.NextPgpObject();
                if (obj is PgpEncryptedDataList)
                {
                    enc = (PgpEncryptedDataList)obj;
                }
                else
                {
                    enc = (PgpEncryptedDataList)pgpObjF.NextPgpObject();
                }
                var akp = new AsymmetricKeyParameter(true);
                
                PgpPrivateKey privKey = GetPrivateKey(privateKeyPath);
                PgpPublicKeyEncryptedData pbe = enc.GetEncryptedDataObjects().Cast<PgpPublicKeyEncryptedData>().First();
                Stream clear;
                clear = pbe.GetDataStream(privKey);
                PgpObjectFactory plainFact = new PgpObjectFactory(clear);
                PgpObject message = plainFact.NextPgpObject();
                if (message is PgpCompressedData)
                {
                    PgpCompressedData cData = (PgpCompressedData)message;
                    Stream compDataIn = cData.GetDataStream();
                    PgpObjectFactory o = new PgpObjectFactory(compDataIn);
                    message = o.NextPgpObject();
                    if (message is PgpOnePassSignatureList)
                    {
                        message = o.NextPgpObject();
                        PgpLiteralData Ld = null;
                        Ld = (PgpLiteralData)message;
                        Stream output = File.Create(outputpath + "\\" + Ld.FileName);
                        Stream unc = Ld.GetInputStream();
                        Streams.PipeAll(unc, output);
                    }
                    else
                    {
                        PgpLiteralData Ld = null;
                        Ld = (PgpLiteralData)message;
                        //Stream output = File.Create(outputpath + "\\" + Ld.FileName);
                        Stream output = File.Create(outputpath);
                        Stream unc = Ld.GetInputStream();
                        Streams.PipeAll(unc, output);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
