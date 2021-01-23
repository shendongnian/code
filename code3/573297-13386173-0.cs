    using System;
    using System.Text;
    using System.Security.Cryptography;
    
    public class Test
    {
        public static string Encrypt(string toEncrypt, string key, bool useHashing) 
        {     
            byte[] keyArray;     
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);      
    
            if (useHashing)     
            {         
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));     
            }     
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);      
    
            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;     
            // tdes.Mode = CipherMode.CBC;  // which is default     
            // tdes.Padding = PaddingMode.PKCS7;  // which is default
            
            Console.WriteLine("iv: {0}", Convert.ToBase64String(tdes.IV));
    
            ICryptoTransform cTransform = tdes.CreateEncryptor();     
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0,
                toEncryptArray.Length);      
            return Convert.ToBase64String(resultArray, 0, resultArray.Length); 
        }  
    
        public static void Main()
        {
            Console.WriteLine("encrypted as: {0}", Encrypt("12345", "abcdefghijklmnop", false));
        }
    }
