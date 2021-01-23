    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    
    using Synercoding.CodeGuard;
    
    namespace Synercoding.Encryption.Hashing
    {
        /// <summary>
        /// Class to verify and generate SHA512 hashes
        /// </summary>
        public static class SHA512Hash
        {
            /// <summary>
            /// Creates a SHA512 hexadecimal string based on the input
            /// </summary>
            /// <param name="input">The string to hash</param>
            /// <returns>A SHA512 hex string</returns>
            public static string GetHash(string input)
            {
                Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(input), "param input can't be null or empty");
    
                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();
    
                using (SHA512 SHA512Hash = SHA512.Create())
                {
                    // Convert the input string to a byte array and compute the hash.
                    byte[] data = SHA512Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
    
                    // Loop through each byte of the hashed data 
                    // and format each one as a hexadecimal string.
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                }
    
                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
    
            /// <summary>
            /// Creates a SHA512 hash based on the input
            /// </summary>
            /// <param name="input">The string to hash</param>
            /// <returns>A SHA512 hash in byte format</returns>
            public static byte[] GetByteHash(string input)
            {
                Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(input), "param input can't be null or empty");
    
                byte[] data;
    
                using (SHA512 SHA512Hash = SHA512.Create())
                {
                    // Convert the input string to a byte array and compute the hash.
                    data = SHA512Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                }
    
                return data;
            }
    
            /// <summary>
            /// Verifies the input with the hash.
            /// </summary>
            /// <param name="input">The input to compare</param>
            /// <param name="hash">The hash to compare the input with</param>
            /// <returns>True is the input validates.</returns>
            public static bool VerifyHash(string input, string hash)
            {
                Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(input), "param input can't be null or empty");
                Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(hash), "param hash can't be null or empty");
                Guard.Requires<ArgumentNullException>(hash.Length == 128, "param hash must be 128 chars long");
    
                // Hash the input.
                string hashOfInput = GetHash(input);
    
                // Create a StringComparer an compare the hashes.
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;
    
                if (0 == comparer.Compare(hashOfInput, hash))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    
            /// <summary>
            /// Verifies the input with the hash.
            /// </summary>
            /// <param name="input">The input to compare</param>
            /// <param name="hash">The hash to compare the input with</param>
            /// <returns>True is the input validates.</returns>
            public static bool VerifyHash(string input, byte[] hash)
            {
                Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(input), "param input can't be null or empty");
                Guard.Requires<ArgumentNullException>(hash != null, "param hash can't be null");
                Guard.Requires<ArgumentNullException>(hash.Length == 512 / 8, "param hash must be 512bits (64 bytes) long");
    
                // Hash the input.
                byte[] hashOfInput = GetByteHash(input);
    
                if (hashOfInput.SequenceEqual(hash))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
