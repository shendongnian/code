     internal static void Encrypt(string inputfile, string outputfile)
     {
         Cryptology.EncryptFile(inputfile, outputfile, password);
     }
     internal static void Decrypt(string inputfile, string outputfile)
     {
         Cryptology.DecryptFile(inputfile, outputfile, password);
     }
