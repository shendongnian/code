    /// <summary>
    /// Generates a salt for use with the Hash method.
    /// </summary>
    /// <param name="length">The length of string to generate.</param>
    /// <returns>A random salt.</returns>
    public static string GenerateSalt(int length) {
        // Check the length isn't too short.
        if (length < MIN_LENGTH) {
            throw new ArgumentOutOfRangeException("length", "Please increase the salt length to meet the minimum acceptable value of " + MIN_LENGTH + " characters.");
        }
        
        // Where we'll put our generated salt.
        StringBuilder salt = new StringBuilder(length);
    
        // Fill our string with random characters.
        Random rnd = new Random();
        string chars = "0123456798ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        for (int i = 0; i < length; i++) {
          salt.Append(chars[rnd.Next(chars.Length)]);
        }
        
        // Return the salt.
        return salt.ToString();
    }
