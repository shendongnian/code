    using System.Security.Cryptography;
    
    using( RandomNumberGenerator rng = new RandomNumberGenerator() ) {
        
        Byte[] bytes = new Byte[12]; // Use a multiple of 3 (e.g. 3, 6, 12) to prevent output with trailing padding '=' characters).
        rng.GetBytes( bytes );
        
        String sendThisInEmailAndStoreInDB = Convert.ToBase64String( bytes );
    }
