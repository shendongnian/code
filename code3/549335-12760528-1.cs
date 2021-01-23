        /// <summary>Hash a password using the OpenBSD bcrypt scheme.</summary>
        /// <exception cref="ArgumentException">Thrown when one or more arguments have unsupported or
        ///                                     illegal values.</exception>
        /// <param name="input">The password to hash.</param>
        /// <param name="salt">    the salt to hash with (perhaps generated using BCrypt.gensalt).</param>
        /// <returns>The hashed password</returns>
        public static string HashPassword(string input, string salt)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (string.IsNullOrEmpty(salt))
                throw new ArgumentException("Invalid salt", "salt");
            // Determinthe starting offset and validate the salt
            int startingOffset;
            char minor = (char)0;
            if (salt[0] != '$' || salt[1] != '2')
                throw new SaltParseException("Invalid salt version");
            if (salt[2] == '$')
                startingOffset = 3;
            else
            {
                minor = salt[2];
                if (minor != 'a' || salt[3] != '$')
                    throw new SaltParseException("Invalid salt revision");
                startingOffset = 4;
            }
            // Extract number of rounds
            if (salt[startingOffset + 2] > '$')
                throw new SaltParseException("Missing salt rounds");
            // Extract details from salt
            int logRounds = Convert.ToInt32(salt.Substring(startingOffset, 2));
            string extractedSalt = salt.Substring(startingOffset + 3, 22);
            byte[] inputBytes = Encoding.UTF8.GetBytes((input + (minor >= 'a' ? "\0" : "")));
            byte[] saltBytes = DecodeBase64(extractedSalt, BCRYPT_SALT_LEN);
            BCrypt bCrypt = new BCrypt();
            byte[] hashed = bCrypt.CryptRaw(inputBytes, saltBytes, logRounds);
            // Generate result string
            StringBuilder result = new StringBuilder();
            result.Append("$2");
            if (minor >= 'a')
                result.Append(minor);
            result.AppendFormat("${0:00}$", logRounds);
            result.Append(EncodeBase64(saltBytes, saltBytes.Length));
            result.Append(EncodeBase64(hashed, (_BfCryptCiphertext.Length * 4) - 1));
            return result.ToString();
        }
