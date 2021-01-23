    string crypt = "blahblahblah";
    string EncryptAndEncode = EncryptionHelper.EncryptAndEncode(crypt);            
    Console.WriteLine(EncryptAndEncode);
    Console.WriteLine(EncryptionHelper.DecodeAndDecrypt(EncryptAndEncode));
    Console.ReadLine();
