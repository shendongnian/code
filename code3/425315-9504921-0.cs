    PgpEncryptedDataGenerator encryptedDataGenerator = // ...
    foreach(PgpPublicKey publicKey in publicKeys){
      encryptedDataGenerator.AddMethod(publicKey);
    }
    encryptedDataGenerator.Open(outputStream, buffer);
    
