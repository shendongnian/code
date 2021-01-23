            bool isPKZip = IOHelper.CheckSignature(empaquetado, 4, IOHelper.SignatureZip);
            Assert.IsTrue(isPKZip, "No es ZIP el empaquetado : " + empaquetado);
    // http://blog.somecreativity.com/2008/04/08/how-to-check-if-a-file-is-compressed-in-c/
        public static partial class IOHelper
        {
            public const string SignatureGzip = "1F-8B-08";
            public const string SignatureZip = "50-4B-03-04";
            
            public static bool CheckSignature(string filepath, int signatureSize, string expectedSignature)
            {
                if (String.IsNullOrEmpty(filepath)) throw new ArgumentException("Must specify a filepath");
                if (String.IsNullOrEmpty(expectedSignature)) throw new ArgumentException("Must specify a value for the expected file signature");
                using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    if (fs.Length < signatureSize)
                        return false;
                    byte[] signature = new byte[signatureSize];
                    int bytesRequired = signatureSize;
                    int index = 0;
                    while (bytesRequired > 0)
                    {
                        int bytesRead = fs.Read(signature, index, bytesRequired);
                        bytesRequired -= bytesRead;
                        index += bytesRead;
                    }
                    string actualSignature = BitConverter.ToString(signature);
                    if (actualSignature == expectedSignature)
                        return true;
                    else
                        return false;
                }
            }
         
        }
