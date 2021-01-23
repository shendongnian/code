    private static bool DecryptFile(Stream inputStream, string outputDir, char[] passPhrase, string privateKeyLoc)
		{
			try
			{
				using (var newStream = PgpUtilities.GetDecoderStream(inputStream))
				{
					PgpObjectFactory pgpObjF = new PgpObjectFactory(newStream);
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
					PgpPrivateKey privKey = GetPrivateKey(privateKeyLoc, passPhrase, logger);
					PgpPublicKeyEncryptedData pbe = enc.GetEncryptedDataObjects().Cast<PgpPublicKeyEncryptedData>().First();
					using (Stream clear = pbe.GetDataStream(privKey))
					{
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
							}
							PgpLiteralData Ld = null;
							Ld = (PgpLiteralData)message;
							using (Stream output = File.Create(outputDir + "\\" + Ld.FileName))
							{
								Stream unc = Ld.GetInputStream();
								Streams.PipeAll(unc, output);
							}
						}
					}
				}
				return true;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
				return false;
			}
		}
