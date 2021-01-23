        /// <summary>
        /// Generates a (SHA1) hashed string, by using the passphrase as a poor man's salt.
        /// </summary>
        public static string RenderHash(this string value, string passPhrase)
        {
            // Append the passphrase to the value
            value += passPhrase;
            // Convert the string value to a byte array 
            // Note: I've used the UTF8 encoding here
            byte[] buffer = Encoding.UTF8.GetBytes(value);
            // And automagically convert it to a hashed string
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
            return hash;
        }
