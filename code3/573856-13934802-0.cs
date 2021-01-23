    class Security
    {
       ...
       public void generate(string Password)
       {
       string hash, salt;
       new SaltedHash().GetHashAndSaltString(Password,out hash,out salt);
       //Store the hash and salt
       }
       ...
    }
