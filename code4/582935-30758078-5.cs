    using System.IO;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Cryptography;
    using System.Globalization;
    // from http://stackoverflow.com/questions/311165/how-do-you-convert-byte-array-to-hexadecimal-string-and-vice-versa
    public static byte[] HexStringToByteArray(String hex)
    {
        int NumberChars = hex.Length;
        byte[] bytes = new byte[NumberChars / 2];
        for (int i = 0; i < NumberChars; i += 2) bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
    
        return bytes;
    }
    // psEncrypted - this is the output from powershell> $psEncrypted = ConvertFrom-SecureString -SecureString $aSecureString -key (1..16)
    // key - make sure you add size checking 
    // notes: this will throw an cryptographic invalid padding exception if it cannot decrypt correctly (wrong key)
    public static SecureString ConvertToSecureString(string psEncrypted, byte[] key)
    {
        // '|' is indeed the separater
        byte[] asBytes = Convert.FromBase64String( psEncrypted);
        string[] strArray = Encoding.Unicode.GetString(asBytes).Split(new[] { '|' });
    
        if (strArray.Length != 3) throw new InvalidDataException("input had incorrect format");
    
        // strArray[0] is a static header, unused in our case
        // you know strArray[1] is a base64 string by the '=' at the end
        // you know strArray[2] is a hex-string because it is [0-9a-f]
        byte[] rgbIV = Convert.FromBase64String(strArray[1]);
        byte[] cipherBytes = HexStringToByteArray(strArray[2]);
    
        // setup the decrypter
        SecureString str = new SecureString();
        SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create();
        ICryptoTransform transform = algorithm.CreateDecryptor(key, rgbIV);
        using (var stream = new CryptoStream(new MemoryStream(cipherBytes), transform, CryptoStreamMode.Read))
        {
            // using this silly loop format to loop one char at a time
            // so we never store the entire password naked in memory
            int numRed = 0;
            byte[] buffer = new byte[2];
            while( (numRed = stream.Read(buffer, 0, buffer.Length)) > 0 )
            {
                str.AppendChar(Encoding.Unicode.GetString(buffer).ToCharArray()[0]);
            }
        }
    
        //
        // non-production code
        // recover the string; just to check
        // from http://stackoverflow.com/questions/818704/how-to-convert-securestring-to-system-string
        //
        IntPtr valuePtr = IntPtr.Zero;
        try
        {
            valuePtr = Marshal.SecureStringToGlobalAllocUnicode(str);
            string back = Marshal.PtrToStringUni(valuePtr);
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
        }
    
        return str;
    }
    public static SecureString DecryptPassword( string psPasswordFile, byte[] key )
    {
        if( ! File.Exists(psPasswordFile)) throw new ArgumentException("file does not exist: " + psPasswordFile);
    
        string formattedCipherText = File.ReadAllText( psPasswordFile );
    
        return ConvertToSecureString(formattedCipherText, key);
    }
