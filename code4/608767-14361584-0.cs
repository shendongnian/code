    [SecuritySafeCritical]
    public byte[] CryptDeriveKey(string algname, string alghashname, int keySize, byte[] rgbIV)
    {
        if (keySize < 0)
        {
            throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidKeySize"));
        }
        int algidHash = X509Utils.NameOrOidToAlgId(alghashname, OidGroup.HashAlgorithm);
        if (algidHash == 0)
        {
            throw new CryptographicException(Environment.GetResourceString("Cryptography_PasswordDerivedBytes_InvalidAlgorithm"));
        }
        int algid = X509Utils.NameOrOidToAlgId(algname, OidGroup.AllGroups);
        if (algid == 0)
        {
            throw new CryptographicException(Environment.GetResourceString("Cryptography_PasswordDerivedBytes_InvalidAlgorithm"));
        }
        if (rgbIV == null)
        {
            throw new CryptographicException(Environment.GetResourceString("Cryptography_PasswordDerivedBytes_InvalidIV"));
        }
        byte[] o = null;
        DeriveKey(this.ProvHandle, algid, algidHash, this._password, this._password.Length, keySize << 0x10, rgbIV, rgbIV.Length, JitHelpers.GetObjectHandleOnStack<byte[]>(ref o));
        return o;
    }
