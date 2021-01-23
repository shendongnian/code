    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace Encrypto
    {
    	public static class Program
    	{
    		public static void Main()
    		{
    
    			const string password = "test";
    			const string text = "test";
    			var cipherText = Aes.Encrypt(password, text);
    			var decrypted = Aes.Decrypt(password, cipherText);
    
    			Console.WriteLine(decrypted);
    			Console.ReadKey();
    		}
    	}
    
    	internal static class Aes
    	{
    		public static EncryptedData Encrypt(string password, string data)
    		{
    			return Transform(true, password, data, null) as EncryptedData;
    		}
    
    		public static string Decrypt(string password, EncryptedData data)
    		{
    			return Transform(false, password, data.DataString, data.SaltString) as string;
    		}
    
    		private static object Transform(bool encrypt, string password, string data, string saltString)
    		{
    			using (var aes = new AesManaged())
    			{
    				aes.Mode = CipherMode.CBC;
    				aes.Padding = PaddingMode.PKCS7;
    				var keyLen = aes.KeySize/8;
    				var ivLen = aes.BlockSize/8;
    				const int saltSize = 8;
    				const int iterations = 8192;
    
    				var salt = encrypt ? new byte[saltSize] : Convert.FromBase64String(saltString);
    				if (encrypt)
    				{
    					new RNGCryptoServiceProvider().GetBytes(salt);
    				}
    
    				var bcKey = new Rfc2898DeriveBytes("BLK" + password, salt, iterations).GetBytes(keyLen);
    				var iv = new Rfc2898DeriveBytes("IV" + password, salt, iterations).GetBytes(ivLen);
    				var macKey = new Rfc2898DeriveBytes("MAC" + password, salt, iterations).GetBytes(16);
    
    				aes.Key = bcKey;
    				aes.IV = iv;
    
    				var rawData = encrypt ? Encoding.UTF8.GetBytes(data) : Convert.FromBase64String(data);
    
    				using (var transform = encrypt ? aes.CreateEncryptor() : aes.CreateDecryptor())
    				using (var memoryStream = encrypt ? new MemoryStream() : new MemoryStream(rawData))
    				using (var cryptoStream = new CryptoStream(memoryStream, transform, encrypt ? CryptoStreamMode.Write : CryptoStreamMode.Read))
    				{
    					if (encrypt)
    					{
    						cryptoStream.Write(rawData, 0, rawData.Length);
    						cryptoStream.FlushFinalBlock();
    						return new EncryptedData(salt, macKey, memoryStream.ToArray());
    					}
    					var originalData = new byte[rawData.Length];
    					var count = cryptoStream.Read(originalData, 0, originalData.Length);
    
    					return Encoding.UTF8.GetString(originalData, 0, count);
    				}
    			}
    		}
    
    		public class EncryptedData
    		{
    			public EncryptedData(byte[] salt, byte[] mac, byte[] data)
    			{
    				Salt = salt;
    				MAC = mac;
    				Data = data;
    			}
    
    			private byte[] Salt { get; set; }
    
    			public string SaltString
    			{
    				get { return Convert.ToBase64String(Salt); }
    			}
    
    			private byte[] MAC { get; set; }
    
    			private byte[] Data { get; set; }
    
    			public string DataString
    			{
    				get { return Convert.ToBase64String(Data); }
    			}
    		}
    	}
    }
