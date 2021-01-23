    class MyAuthClass {
      private const int SaltSize = 40;
      private ThreadLocal<HashAlgorithm> Hasher;
      public MyAuthClass ()
      {
        // This is 'ThreadLocal' so your methods which use this are thread-safe.
        Hasher = new ThreadLocal<HashAlgorithm>( 
          () => new HMACSHA256(Encoding.ASCII.GetBytes(_configurationProvider.PasswordEncryptionKey)
        );
      } 
      private User CreateUser(string email, string password) {
        var rng = new RNGCryptoServiceProvider();
        var pwBytes = Encoding.Unicode.GetBytes(password);
        var salt = new byte[SaltSize];
        rng.GetBytes(salt);
        
        var hasher = Hasher.Value;
        hasher.TransformBlock(salt, 0, SaltSize, salt, 0);
        hasher.TransformFinalBlock(pwBytes, 0, pwBytes.Length);
        var finalHash = hasher.Hash;
        return new User { UserName = email, PasswordHash = finalHash, Salt = salt };
      }
    }
