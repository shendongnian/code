    private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes){
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt)) {
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
