    public class Rfc2898PasswordEncoder
    {
        private int _byteLength = 160 / 8; // 160 bit hash length
        public class EncodedPassword
        {
            public byte[] Hash { get; set; }
            public byte[] Salt { get; set; }
            public int Iterations { get; set; }
        }
        public EncodedPassword EncodePassword(string password, int iterations)
        {
            var populatedPassword = new EncodedPassword
            {
                Salt = CreateSalt(),
                Iterations = iterations
            };
            // Add Hash
            populatedPassword.Hash = CreateHash(password, populatedPassword.Salt, iterations);
            return populatedPassword;
        }
        public bool ValidatePassword(string password, EncodedPassword encodedPassword)
        {
            // Create Hash
            var testHash = CreateHash(password, encodedPassword.Salt, encodedPassword.Iterations);
            return testHash == encodedPassword.Hash;
        }
        public byte[] CreateSalt()
        {
            var salt = new byte[_byteLength]; // Salt should be same length as hash
            using (var saltGenerator = new RNGCryptoServiceProvider())
            {
                saltGenerator.GetBytes(salt);
            }
            return salt;
        }
        private byte[] CreateHash(string password, byte[] salt, long iterations)
        {
            byte[] hash;
            using (var hashGenerator = new Rfc2898DeriveBytes(password, salt, (int)iterations))
            {
                hash = hashGenerator.GetBytes(_byteLength);
            }
            return hash;
        }
    } 
