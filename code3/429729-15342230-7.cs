	namespace System.Security.Cryptography
	{
		// Summary:
		//     Provides methods for protecting and unprotecting data. This class cannot
		//     be inherited.
		public sealed class ProtectedData
		{
			public static byte[] Protect(byte[] userData, 
				byte[] optionalEntropy, DataProtectionScope scope);
			public static byte[] Unprotect(byte[] encryptedData, 
				byte[] optionalEntropy, DataProtectionScope scope);
		}
	}
