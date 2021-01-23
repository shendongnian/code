    public sealed class AesManagedSymmetricCryptography : SymmetricCryptography<AesManaged>
    {
        #region Constructors
        public AesManagedSymmetricCryptography()
        {
        }
        public AesManagedSymmetricCryptography(byte[] key, byte[] iv)
            : base(key, iv)
        {
        }
        public AesManagedSymmetricCryptography(string password, string salt)
            : base(password, salt)
        {
        }
        public AesManagedSymmetricCryptography(string password, string salt, int iterations)
            : base(password, salt, iterations)
        {
        }
        #endregion
    }
