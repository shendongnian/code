    /* http://csrc.nist.gov/publications/fips/fips197/fips-197.pdf page 35 and 36 */
    var passwordBytes = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 
       0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f };
    var unencryptedBytes = new byte[] { 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66,
       0x77, 0x88, 0x99, 0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff };
    var initvectorBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
       0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
    using (var aes = new AesManaged())
    {
       aes.BlockSize = 128; /* size in bits */
       aes.KeySize = 128; /* size in bits */
       aes.Key = passwordBytes;
       aes.IV = initvectorBytes;
       using (var memoryStream = new MemoryStream())
       {
          using (var cryptoStream = new CryptoStream(
             memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
          {
             cryptoStream.Write(unencryptedBytes, 0, unencryptedBytes.Length);
             cryptoStream.FlushFinalBlock();
             var stream = memoryStream.ToArray();
             /* now you get: 
                69-c4-e0-d8-6a-7b-04-30-d8-cd-b7-80-70-b4-c5-5a = 128 bit
                according to http://testprotect.com/appendix/AEScalc and fips-197.pdf
             */
             var output = BitConverter.ToString(stream);
          }
       }
    }
