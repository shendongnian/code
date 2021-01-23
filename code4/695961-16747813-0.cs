    public class HashProvider
    {
        /// <summary>
        /// Computes the SHA1 hash from the given string.
        /// </summary>
        /// <param name="stringToHash">The string to hash.</param>
        /// <returns></returns>
        public static string GetSHA1Hash(string stringToHash)
        {
            var data = Encoding.UTF8.GetBytes(stringToHash);
            var hashData = new SHA1CryptoServiceProvider().ComputeHash(data);
            return String.Concat(hashData.Select(b => b.ToString("X2")));
        }
        /// <summary>
        /// Computes the SHA1 hash from the given string, and then encodes the hash as a Base64 string.
        /// </summary>
        /// <param name="stringToHash">The string to hash.</param>
        /// <returns></returns>
        public static string GetSHA1toBase64Hash(string stringToHash)
        {
            var data = Encoding.UTF8.GetBytes(stringToHash);
            var hashData = new SHA1CryptoServiceProvider().ComputeHash(data);
            return Convert.ToBase64String(hashData);
        }
    }
