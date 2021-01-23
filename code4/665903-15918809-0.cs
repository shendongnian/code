    class Class1
    {
          //  Call this function to remove the key from memory after use for security
          [System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint="RtlZeroMemory")]
          public static extern bool ZeroMemory(IntPtr Destination, int Length);
		
      // Function to Generate a 64 bits Key.
      static string GenerateKey() 
      {
         // Create an instance of Symetric Algorithm. Key and IV is generated automatically.
         DESCryptoServiceProvider desCrypto =(DESCryptoServiceProvider)DESCryptoServiceProvider.Create();
         // Use the Automatically generated key for Encryption. 
         return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
      }
      static void EncryptFile(string sInputFilename,
         string sOutputFilename, 
         string sKey) 
      {
         FileStream fsInput = new FileStream(sInputFilename, 
            FileMode.Open, 
            FileAccess.Read);
         FileStream fsEncrypted = new FileStream(sOutputFilename, 
            FileMode.Create, 
            FileAccess.Write);
         DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
         DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
         DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
         ICryptoTransform desencrypt = DES.CreateEncryptor();
         CryptoStream cryptostream = new CryptoStream(fsEncrypted, 
            desencrypt, 
            CryptoStreamMode.Write); 
         byte[] bytearrayinput = new byte[fsInput.Length];
         fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
         cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
         cryptostream.Close();
         fsInput.Close();
         fsEncrypted.Close();
      }
      static void DecryptFile(string sInputFilename, 
         string sOutputFilename,
         string sKey)
      {
         DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
         //A 64 bit key and IV is required for this provider.
         //Set secret key For DES algorithm.
         DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
         //Set initialization vector.
         DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
         //Create a file stream to read the encrypted file back.
         FileStream fsread = new FileStream(sInputFilename, 
            FileMode.Open, 
            FileAccess.Read);
         //Create a DES decryptor from the DES instance.
         ICryptoTransform desdecrypt = DES.CreateDecryptor();
         //Create crypto stream set to read and do a 
         //DES decryption transform on incoming bytes.
         CryptoStream cryptostreamDecr = new CryptoStream(fsread, 
            desdecrypt,
            CryptoStreamMode.Read);
         //Print the contents of the decrypted file.
         StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
         fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
         fsDecrypted.Flush();
         fsDecrypted.Close();
      } 
      static void Main()
      {
         // Must be 64 bits, 8 bytes.
         // Distribute this key to the user who will decrypt this file.
         string sSecretKey;
         
         // Get the Key for the file to Encrypt.
         sSecretKey = GenerateKey();
         // For additional security Pin the key.
         GCHandle gch = GCHandle.Alloc( sSecretKey,GCHandleType.Pinned );
         
         // Encrypt the file.        
         EncryptFile(@"C:\MyData.txt", 
            @"C:\Encrypted.txt", 
            sSecretKey);
         // Decrypt the file.
         DecryptFile(@"C:\Encrypted.txt", 
            @"C:\Decrypted.txt", 
            sSecretKey);
         // Remove the Key from memory. 
         ZeroMemory(gch.AddrOfPinnedObject(), sSecretKey.Length * 2);
         gch.Free();
      }
    }
      }
