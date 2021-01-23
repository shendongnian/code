    void Main()
    {
    
    	PGPEncryptDecrypt pgp = new PGPEncryptDecrypt();
    	
    	string passPhrase = "hello world!";
    	
    	//full path to file to encrypt
    	string origFilePath = @"c:\Temp\test.txt"; 
    	//folder to store encrypted file
    	string encryptedFilePath = @"C:\Temp\Output\";
    	//folder to store unencrypted file
    	string unencryptedFilePath = @"C:\Temp\Output\";
    	//path to public key file 
    	string publicKeyFile = @"c:\Temp\dummy.pkr";
    	//path to private key file (this file should be kept at client, AND in a secure place, far from prying eyes and tinkering hands)
    	string privateKeyFile = @"c:\Temp\dummy.skr";
    	
    	pgp.Encrypt(origFilePath, publicKeyFile, encryptedFilePath);
    	pgp.Decrypt(encryptedFilePath + "test.txt.asc", privateKeyFile, passPhrase, unencryptedFilePath);
    	 
    }
    
    // Define other methods and classes here
    public class PGPEncryptDecrypt
    {
       
       public PGPEncryptDecrypt()
       {
           
       }
       
       /**
       * A simple routine that opens a key ring file and loads the first available key suitable for
       * encryption.
       *
       * @param in
       * @return
       * @m_out
       * @
       */
       private static PgpPublicKey ReadPublicKey(Stream inputStream)
       {
           
           inputStream = PgpUtilities.GetDecoderStream(inputStream);
           PgpPublicKeyRingBundle pgpPub = new PgpPublicKeyRingBundle(inputStream);
           //
           // we just loop through the collection till we find a key suitable for encryption, in the real
           // world you would probably want to be a bit smarter about this.
           //
           //
           // iterate through the key rings.
           //
           foreach (PgpPublicKeyRing kRing in pgpPub.GetKeyRings())
           {
               
               foreach (PgpPublicKey k in kRing.GetPublicKeys())
               {
                   
                   if (k.IsEncryptionKey)
                   {
                       
                       return k;
                       
                   }
                   
                   
               }
               
               
           }
           
           throw new ArgumentException("Can't find encryption key in key ring.");
           
       }
       
       /**
       * Search a secret key ring collection for a secret key corresponding to
       * keyId if it exists.
       *
       * @param pgpSec a secret key ring collection.
       * @param keyId keyId we want.
       * @param pass passphrase to decrypt secret key with.
       * @return
       */
       private static PgpPrivateKey FindSecretKey(PgpSecretKeyRingBundle pgpSec, long keyId, char[] pass)
       {
           
           PgpSecretKey pgpSecKey = pgpSec.GetSecretKey(keyId);
           if (pgpSecKey == null)
           {
               
               return null;
               
           }
           
           return pgpSecKey.ExtractPrivateKey(pass);
           
       }
       
       /**
       * decrypt the passed in message stream
       */
       private static void DecryptFile(Stream inputStream, Stream keyIn, char[] passwd, string defaultFileName, string pathToSaveFile)
       {
           
           inputStream = PgpUtilities.GetDecoderStream(inputStream);
           try
           {
               
               PgpObjectFactory pgpF = new PgpObjectFactory(inputStream);
               PgpEncryptedDataList enc;
               PgpObject o = pgpF.NextPgpObject();
               //
               // the first object might be a PGP marker packet.
               //
               if (o is PgpEncryptedDataList)
               {
                   
                   enc = (PgpEncryptedDataList)o;
                   
               }
               
               else
               {
                   
                   enc = (PgpEncryptedDataList)pgpF.NextPgpObject();
                   
               }
               
               //
               // find the secret key
               //
               PgpPrivateKey sKey = null;
               PgpPublicKeyEncryptedData pbe = null;
               PgpSecretKeyRingBundle pgpSec = new PgpSecretKeyRingBundle(
               PgpUtilities.GetDecoderStream(keyIn));
               foreach (PgpPublicKeyEncryptedData pked in enc.GetEncryptedDataObjects())
               {
                   
                   sKey = FindSecretKey(pgpSec, pked.KeyId, passwd);
                   if (sKey != null)
                   {
                       
                       pbe = pked;
                       break;
                       
                   }
                   
                   
               }
               
               if (sKey == null)
               {
                   
                   throw new ArgumentException("secret key for message not found.");
                   
               }
               
               Stream clear = pbe.GetDataStream(sKey);
               PgpObjectFactory plainFact = new PgpObjectFactory(clear);
               PgpObject message = plainFact.NextPgpObject();
               if (message is PgpCompressedData)
               {
                   
                   PgpCompressedData cData = (PgpCompressedData)message;
                   PgpObjectFactory pgpFact = new PgpObjectFactory(cData.GetDataStream());
                   message = pgpFact.NextPgpObject();
                   
               }
               
               if (message is PgpLiteralData)
               {
                   
                   PgpLiteralData ld = (PgpLiteralData)message;
                   string outFileName = ld.FileName;
                   if (outFileName.Length == 0)
                   {
                       
                       outFileName = defaultFileName;
                       
                   }
                   
                   Stream fOut = File.Create(pathToSaveFile + outFileName);
                   Stream unc = ld.GetInputStream();
                   Streams.PipeAll(unc, fOut);
                   fOut.Close();
                   
               }
               
               else if (message is PgpOnePassSignatureList)
               {
                   
                   throw new PgpException("encrypted message contains a signed message - not literal data.");
                   
               }
               
               else
               {
                   
                   throw new PgpException("message is not a simple encrypted file - type unknown.");
                   
               }
               
               if (pbe.IsIntegrityProtected())
               {
                   
                   if (!pbe.Verify())
                   {
                       
                       Console.Error.WriteLine("message failed integrity check");
                       
                   }
                   
                   else
                   {
                       
                       Console.Error.WriteLine("message integrity check passed");
                       
                   }
                   
                   
               }
               
               else
               {
                   
                   Console.Error.WriteLine("no message integrity check");
                   
               }
               
               
           }
           
           catch (PgpException e)
           {
               
               Console.Error.WriteLine(e);
               Exception underlyingException = e.InnerException;
               if (underlyingException != null)
               {
                   
                   Console.Error.WriteLine(underlyingException.Message);
                   Console.Error.WriteLine(underlyingException.StackTrace);
                   
               }
               
               
           }
           
           
       }
       
       private static void EncryptFile(Stream outputStream, string fileName, PgpPublicKey encKey, bool armor, bool withIntegrityCheck)
       {
           
           if (armor)
           {
               
               outputStream = new ArmoredOutputStream(outputStream);
               
           }
           
           try
           {
               
               MemoryStream bOut = new MemoryStream();
               PgpCompressedDataGenerator comData = new PgpCompressedDataGenerator(
               CompressionAlgorithmTag.Zip);
               PgpUtilities.WriteFileToLiteralData(
               comData.Open(bOut),
               PgpLiteralData.Binary,
               new FileInfo(fileName));
               comData.Close();
               PgpEncryptedDataGenerator cPk = new PgpEncryptedDataGenerator(
               SymmetricKeyAlgorithmTag.Cast5, withIntegrityCheck, new SecureRandom());
               cPk.AddMethod(encKey);
               byte[] bytes = bOut.ToArray();
               Stream cOut = cPk.Open(outputStream, bytes.Length);
               cOut.Write(bytes, 0, bytes.Length);
               cOut.Close();
               if (armor)
               {
                   
                   outputStream.Close();
                   
               }
               
               
           }
           
           catch (PgpException e)
           {
               
               Console.Error.WriteLine(e);
               Exception underlyingException = e.InnerException;
               if (underlyingException != null)
               {
                   
                   Console.Error.WriteLine(underlyingException.Message);
                   Console.Error.WriteLine(underlyingException.StackTrace);
                   
               }
               
               
           }
           
           
       }
       
       public void Encrypt(string filePath, string publicKeyFile, string pathToSaveFile)
       {
           
           Stream keyIn, fos;
           keyIn = File.OpenRead(publicKeyFile);
           string[] fileSplit = filePath.Split('\\');
           string fileName = fileSplit[fileSplit.Length - 1];
           fos = File.Create(pathToSaveFile + fileName + ".asc");
           EncryptFile(fos, filePath, ReadPublicKey(keyIn), true, true);
           keyIn.Close();
           fos.Close();
           
       }
       
       public void Decrypt(string filePath, string privateKeyFile, string passPhrase, string pathToSaveFile)
       {
           
           Stream fin = File.OpenRead(filePath);
           Stream keyIn = File.OpenRead(privateKeyFile);
           DecryptFile(fin, keyIn, passPhrase.ToCharArray(), new FileInfo(filePath).Name + ".out", pathToSaveFile);
           fin.Close();
           keyIn.Close();
           
       }
       
       
    }
</pre>I still haven't done final tests on this, but it all seems to work (so far). For LinqPad, add a reference to <strong>BouncyCastle.1.7.0\lib\Net40-Client\BouncyCastle.Crypto.dll</strong> and my imports are:<pre>
    Microsoft.VisualBasic
    Org.BouncyCastle.Bcpg
    Org.BouncyCastle.Bcpg.OpenPgp
    Org.BouncyCastle.Bcpg.Sig
    Org.BouncyCastle.Crypto
    Org.BouncyCastle.Crypto.Generators
    Org.BouncyCastle.Crypto.Parameters
    Org.BouncyCastle.Math
    Org.BouncyCastle.Security
    System
    System.Collections
    System.IO
