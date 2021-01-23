    [EncryptionExtension(Decrypt = DecryptMode.Response, Encrypt = EncryptMode.None, Target = Target.Body)]
    public string HelloWorld()
    {
        object[] results = this.Invoke("HelloWorld", new object[] { });
        return ((string)(results[0]));
    }
