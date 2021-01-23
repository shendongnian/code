    // sampleDESCBCEncryption
    private static int sampleDESCBCEncryption( 
        byte[] secretKey, byte[] initVector, byte[] plainText, byte[] cipherText, int
        dataLength ) 
        throws CryptoException, IOException
    {
        // Create a new DES key based on the 8 bytes in the secretKey array
        DESKey key = new DESKey( secretKey );
        
        // Create a new initialization vector using the 8 bytes in initVector
        InitializationVector iv = new InitializationVector( initVector );
        
        // Create a new byte array output stream for use in encryption
        NoCopyByteArrayOutputStream out = new NoCopyByteArrayOutputStream();
                
        // Create a new instance of a BlockEncryptor passing in an instance of a CBC encryptor engine
        // (containing an instance of a DES encryptor engine), the initialization vector, and the
        // output stream
        BlockEncryptor cryptoStream = new BlockEncryptor( 
            new CBCEncryptorEngine( new DESEncryptorEngine( key ), iv ), out );
        
        // Write dataLength bytes from plainText to the CFB encryptor stream
        cryptoStream.write( plainText, 0, dataLength );
        cryptoStream.close();
        
        // Now copy the encrypted bytes from out into cipherText and return the length
        int finalLength = out.size();
        System.arraycopy( out.getByteArray(), 0, cipherText, 0, finalLength );
        return finalLength;
    }    
