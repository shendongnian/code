    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Security.Cryptography;
    using System.Text;
    using System.IO;
    
    namespace demo.encry
    {
        public class Crypto
        {
            public Crypto()
            {
            }
    
            public String encrypto(string te, string ps,
                  string Salt = "Kosher", string HashAlgorithm = "SHA1",
                  int PasswordIterations = 2, string InitialVector = "OFRna73m*aze01xY",
                  int KeySize = 256)
            {
                if (string.IsNullOrEmpty(te))
                    return "";
                byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
                byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
                byte[] PlainTextBytes = Encoding.UTF8.GetBytes(te);
                PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(ps, SaltValueBytes, HashAlgorithm, PasswordIterations);
                byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
                RijndaelManaged SymmetricKey = new RijndaelManaged();
    
                SymmetricKey.Mode = CipherMode.CBC;
                byte[] CipherTextBytes = null;
                using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes))
                {
                    using (MemoryStream MemStream = new MemoryStream())
                    {
                        using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
                        {
                            CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
                            CryptoStream.FlushFinalBlock();
                            CipherTextBytes = MemStream.ToArray();
                            MemStream.Close();
                            CryptoStream.Close();
                        }
                    }
    
    
    
                }
                SymmetricKey.Clear();
                return Convert.ToBase64String(CipherTextBytes);
            }
    
            public String decrypto(string ct, string ps,
                  string Salt = "Kosher", string HashAlgorithm = "SHA1",
                 int PasswordIterations = 2, string InitialVector = "OFRna73m*aze01xY",
                 int KeySize = 256)
            {
                if (string.IsNullOrEmpty(ct))
                    return "";
    
                byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
                byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
                byte[] CipherTextBytes = Convert.FromBase64String(ct);
                PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(ps, SaltValueBytes, HashAlgorithm, PasswordIterations);
                byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
                RijndaelManaged SymmetricKey = new RijndaelManaged();
                SymmetricKey.Mode = CipherMode.CBC;
                byte[] PlainTextBytes = new byte[CipherTextBytes.Length];
                int ByteCount = 0;
                using (ICryptoTransform Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, InitialVectorBytes))
                {
                    using (MemoryStream MemStream = new MemoryStream(CipherTextBytes))
                    {
                        using (CryptoStream CryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read))
                        {
    
                            ByteCount = CryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length);
    
                            MemStream.Close();
                            CryptoStream.Close();
                        }
                    }
                }
    
                SymmetricKey.Clear();
                return Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount);
            }
        }
    
    }
