    // Save your password so you can reset it after the object has been serialized.
    [NonSerialized()] 
    private string SavedPassword;
    // This saves the value of Password and Encrpts it so it will be stored Encrypted.
    // I am leaving out the Encrypt code to make it cleaner here.
    [OnSerializing()]
    internal void OnSerializingMethod(StreamingContext context)
    {
        SavedPassword = Password;
        Password = Encrypt(Password);
    }
    // reset the Password after serialization so you can continue to use your object.
    [OnSerialized()]
    internal void OnSerializedMethod(StreamingContext context)
    {
        Password = SavedPassword;
    }
    // On deserialize you need to Decrypt your Password.
    [OnDeserialized()]
    internal void OnDeserializedMethod(StreamingContext context)
    {
        Password = Decrypt(Password);
    }
