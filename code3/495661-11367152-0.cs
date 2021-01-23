        public Org.BouncyCastle.Crypto.AsymmetricKeyParameter ReadAsymmetricKeyParameter(string pemFilename)
        {
            // Make a AsymmetricKeyParameter to represent the read in public key, initialize to null
            Org.BouncyCastle.Crypto.AsymmetricKeyParameter KeyParameter = null;
            // create a filename and open it for a read
            System.IO.TextReader fileStream;
            try
            {
                fileStream = System.IO.File.OpenText(pemFilename);
            }
            catch (Exception)
            {
                Console.Write("An exception has occured opening the file");
                return null;
            } 
            Org.BouncyCastle.OpenSsl.PemReader pemReader;
            try
            {
                pemReader = new Org.BouncyCastle.OpenSsl.PemReader(fileStream);
            }
            catch (Exception)
            {
                Console.Write("An exception has occured creating the pemreader");
                return null;
            }
            try
            {
                KeyParameter = (Org.BouncyCastle.Crypto.AsymmetricKeyParameter)pemReader.ReadObject();
            }
            catch (Exception)
            {
                Console.Write("An exception has occured reading the pemreader");
                return null;
            }
            return KeyParameter;
        }
