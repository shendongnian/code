    using System;
    using System.Configuration;
    using System.Security.Cryptography;
    using System.Text;
    public class TripleDESImp
    {
        public static readonly string Key = ConfigurationManager.AppSettings["Encryption_Key"];
        public static readonly Encoding Encoder = Encoding.UTF8;
        public static string TripleDesEncrypt(string plainText)
        {
            var des = CreateDes(Key);
            var ct = des.CreateEncryptor();
            var input = Encoding.UTF8.GetBytes(plainText);
            var output = ct.TransformFinalBlock(input, 0, input.Length);
            return Convert.ToBase64String(output);
        }
        public static string TripleDesDecrypt(string cypherText)
        {
            var des = CreateDes(Key);
            var ct = des.CreateDecryptor();
            var input = Convert.FromBase64String(cypherText);
            var output = ct.TransformFinalBlock(input, 0, input.Length);
            return Encoding.UTF8.GetString(output);
        }
        public static TripleDES CreateDes(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            var desKey= md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            des.Key = desKey;
            des.IV = new byte[des.BlockSize / 8];
            des.Padding=PaddingMode.PKCS7;
            des.Mode=CipherMode.ECB;
            return des;
        }
    }
    <configuration>
    <appsettings>
    <add key="Encryption_Key" value="put_your_encryption_key_here"/>
    </appsettings>
    <configuration>
