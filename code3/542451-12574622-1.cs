    using System.Security.Cryptography;
    
    using( RandomNumberGenerator rng = new RandomNumberGenerator() ) {
        
        Byte[] bytes = new Byte[8];
        rng.GetBytes( bytes );
        
        String sendThisInEmailAndStoreInDB = Convert.ToBase64String( bytes );
    }
