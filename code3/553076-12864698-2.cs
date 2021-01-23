	#region Preprocessor Directives
	# if __FRAMEWORK_V35 || __FRAMEWORK_V4
	#define __DotNet35Plus
	#endif
	#if !__DotNet35Plus
	#warning AES implementation used by this compile of the library is not NIST certified as FIPS 140-2 compliant
	#endif
	#endregion
	#region Namespaces
	using System;
	using System.Security.Cryptography;
	using System.IO;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization.Formatters.Binary;
	#endregion
	namespace Simple
	{
		public static class AES256Encryption
		{
			private static readonly object _lock = new object();
			private const Int32 KeySize = 256;
	#if __DotNet35Plus
			private static AesCryptoServiceProvider thisCSP = new AesCryptoServiceProvider();
	#else
			private static RijndaelManaged thisCSP = new RijndaelManaged();
	#endif
			private static MemoryStream msEncrypt = new MemoryStream();
			private static CryptoStream csEncrypt;
			private static MemoryStream msDecrypt = new MemoryStream();
			private static CryptoStream csDecrypt;
			public enum stringIOType
			{
				base64EncodedString = 0,
				HexEncodedString = 1
			}
			public static bool NISTCertified()
			{
	#if __DotNet35Plus
				return true;
	#else
				return false;
	#endif
			}
			#region Encryption Methods
			public static byte[] encryptBytes(byte[] Value, string PassPhrase, Encoding PassPhraseEncoding)
			{
				try
				{
					Monitor.Enter(_lock);
					return encryptBytes(Value, getKeyFromPassPhrase(PassPhrase, PassPhraseEncoding), getIVFromPassPhrase(PassPhrase, PassPhraseEncoding));
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			public static byte[] encryptBytes(byte[] Value, byte[] Key, byte[] IV)
			{
				try
				{
					Monitor.Enter(_lock);
	#if __DotNet35Plus
					thisCSP = new AesCryptoServiceProvider();
	#else
					thisCSP = new RijndaelManaged();
	#endif
					thisCSP.KeySize = KeySize;
					Int32 bitLength = Key.Length * 8;
					if (bitLength != thisCSP.KeySize)
					{
						throw new ArgumentException("The supplied key's length [" + bitLength.ToString() + " bits] is not a valid key size for the AES-256 algorithm.", "Key");
					}
					bitLength = IV.Length * 8;
					if (bitLength != thisCSP.BlockSize)
					{
						throw new ArgumentException("The supplied IV's length [" + bitLength.ToString() + " bits] is not a valid IV size for the AES-256 algorithm.", "IV");
					}
					ICryptoTransform Encryptor = thisCSP.CreateEncryptor(Key, IV);
					msEncrypt = new MemoryStream();
					csEncrypt = new CryptoStream(msEncrypt, Encryptor, CryptoStreamMode.Write);
					csEncrypt.Write(Value, 0, Value.Length);
					csEncrypt.FlushFinalBlock();
					Encryptor.Dispose();
					Encryptor = null;
					msEncrypt.Close();
					return msEncrypt.ToArray();
				}
				finally
				{
					thisCSP = null;
					Monitor.Exit(_lock);
				}
			}
			public static string encryptString(string Value, string PassPhrase, Encoding PassPhraseEncoding, Encoding inputEncoding, stringIOType outputType)
			{
				try
				{
					Monitor.Enter(_lock);
					return encryptString(Value, getKeyFromPassPhrase(PassPhrase, PassPhraseEncoding), getIVFromPassPhrase(PassPhrase, PassPhraseEncoding), inputEncoding, outputType);
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			public static string encryptString(string Value, byte[] Key, byte[] IV, Encoding inputEncoding, stringIOType outputType)
			{
				try
				{
					Monitor.Enter(_lock);
					byte[] baseValue = (byte[])Array.CreateInstance(typeof(byte), inputEncoding.GetByteCount(Value));
					baseValue = inputEncoding.GetBytes(Value);
					switch(outputType)
					{
						case stringIOType.base64EncodedString:
							return Convert.ToBase64String(encryptBytes(baseValue, Key, IV));
						case stringIOType.HexEncodedString:
							return ByteArrayToHexString(encryptBytes(baseValue, Key, IV));
						default:
							return Convert.ToBase64String(encryptBytes(baseValue, Key, IV));
					}
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			#endregion
			#region Decryption Methods
			public static byte[] decryptBytes(byte[] Value, string PassPhrase, Encoding PassPhraseEncoding)
			{
				try
				{
					Monitor.Enter(_lock);
					return decryptBytes(Value, getKeyFromPassPhrase(PassPhrase, PassPhraseEncoding), getIVFromPassPhrase(PassPhrase, PassPhraseEncoding));
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			public static byte[] decryptBytes(byte[] Value, byte[] Key, byte[] IV)
			{
				try
				{
					Monitor.Enter(_lock);
	#if __DotNet35Plus
					thisCSP = new AesCryptoServiceProvider();
	#else
					thisCSP = new RijndaelManaged();
	#endif
					thisCSP.KeySize = KeySize;
					Int32 bitLength = Key.Length * 8;
					if (bitLength != thisCSP.KeySize)
					{
						throw new ArgumentException("The supplied key's length [" + bitLength.ToString() + " bits] is not a valid key size for the AES-256 algorithm.", "Key");
					}
					bitLength = IV.Length * 8;
					if (bitLength != thisCSP.BlockSize)
					{
						throw new ArgumentException("The supplied IV's length [" + bitLength.ToString() + " bits] is not a valid IV size for the AES-256 algorithm.", "IV");
					}
					try
					{
						byte[] Decrypted;
						ICryptoTransform Decryptor = thisCSP.CreateDecryptor(Key, IV);
						msDecrypt = new MemoryStream(Value);
						csDecrypt = new CryptoStream(msDecrypt, Decryptor, CryptoStreamMode.Read);
						Decrypted = (byte[])Array.CreateInstance(typeof(byte), msDecrypt.Length);
						csDecrypt.Read(Decrypted, 0, Decrypted.Length);
						Decryptor.Dispose();
						Decryptor = null;
						msDecrypt.Close();
						Int32 trimCount = 0;
						// Remove any block padding left over from encryption algorithm before returning
						for (Int32 i = Decrypted.Length - 1; i >= 0; i--)
						{
							if (Decrypted[i] == 0) { trimCount++; } else { break; }
						}
						if (trimCount > 0)
						{
							byte[] buffer = (byte[])Array.CreateInstance(typeof(byte), Decrypted.Length - trimCount);
							Array.ConstrainedCopy(Decrypted, 0, buffer, 0, buffer.Length);
							Array.Clear(Decrypted, 0, Decrypted.Length);
							Array.Resize<byte>(ref Decrypted, buffer.Length);
							Array.Copy(buffer, Decrypted, buffer.Length);
							buffer = null;
						}
						return Decrypted;
					}
					finally
					{
						thisCSP = null;
					}
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			public static string decryptString(string Value, string PassPhrase, Encoding PassPhraseEncoding, stringIOType inputType, Encoding outputEncoding)
			{
				try
				{
					Monitor.Enter(_lock);
					return decryptString(Value, getKeyFromPassPhrase(PassPhrase, PassPhraseEncoding), getIVFromPassPhrase(PassPhrase, PassPhraseEncoding), inputType, outputEncoding);
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			public static string decryptString(string Value, byte[] Key, byte[] IV, stringIOType inputType, Encoding outputEncoding)
			{
				try
				{
					Monitor.Enter(_lock);
					byte[] baseValue;
					switch (inputType)
					{
						case stringIOType.base64EncodedString:
							baseValue = Convert.FromBase64String(Value);
							break;
						case stringIOType.HexEncodedString:
							baseValue = HexStringToByteArray(Value);
							break;
						default:
							baseValue = Convert.FromBase64String(Value);
							break;
					}
					return outputEncoding.GetString(decryptBytes(baseValue, Key, IV));
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			#endregion
			#region Key/Digest Generation Methods
			public static byte[] getKeyFromPassPhrase(string PassPhrase, Encoding encoder)
			{
				Monitor.Enter(_lock);
				try
				{
					return getDigest(PassPhrase, encoder, 32);
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			public static byte[] getIVFromPassPhrase(string PassPhrase, Encoding encoder)
			{
				Monitor.Enter(_lock);
				try
				{
					byte[] buffer = (byte[])Array.CreateInstance(typeof(byte), encoder.GetByteCount(PassPhrase));
					byte[] reverseBuffer = (byte[])Array.CreateInstance(typeof(byte), encoder.GetByteCount(PassPhrase));
					buffer = encoder.GetBytes(PassPhrase);
					for (Int32 i = 0; i <= buffer.Length - 1; i++)
					{
						reverseBuffer[i] = buffer[buffer.Length - i - 1];
					}
					return getDigest(reverseBuffer, 16);
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			public static byte[] getDigest(string value, Encoding encoder, Int32 digestLength)
			{
				Monitor.Enter(_lock);
				try
				{
					return getDigest(encoder.GetBytes(value), digestLength);
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			public static byte[] getDigest(object value, Int32 digestLength)
			{
				Monitor.Enter(_lock);
				try
				{
					BinaryFormatter bf = new BinaryFormatter();
					MemoryStream ms = new MemoryStream();
					bf.Serialize(ms, value);
					return getDigest(ms.ToArray(), digestLength);
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			public static byte[] getDigest(byte[] value, Int32 digestLength)
			{
				Monitor.Enter(_lock);
				try
				{
					Int32 iterations = 0;
					// Find first non-zero byte value to use to calculate iterations
					for (Int32 i = 0; i < value.Length; i++)
					{
						if (value[i] != 0) { iterations = (Int32)(value[i] * 10); break; }
					}
					// There were no non-zero byte values use the max for iterations
					if (iterations == 0) { iterations = (Int32)(byte.MaxValue * 10); }
					Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(value, new SHA256Managed().ComputeHash(value), iterations);
					return deriveBytes.GetBytes(digestLength);
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			#endregion
			#region HexArray/String String/HexArray Converters
			public static string ByteArrayToHexString(byte[] ba)
			{
				try
				{
					Monitor.Enter(_lock);
					StringBuilder hex = new StringBuilder(ba.Length * 2);
					foreach (byte b in ba)
						hex.AppendFormat("{0:x2}", b);
					return hex.ToString();
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			public static byte[] HexStringToByteArray(String hex)
			{
				try
				{
					Monitor.Enter(_lock);
					int NumberChars = hex.Length;
					byte[] bytes = new byte[NumberChars / 2];
					for (int i = 0; i < NumberChars; i += 2)
						bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
					return bytes;
				}
				finally
				{
					Monitor.Exit(_lock);
				}
			}
			#endregion
		}
	}
