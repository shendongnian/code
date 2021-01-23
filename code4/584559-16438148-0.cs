    /// <summary>
    /// Return the last key we can use to decrypt.
    /// Note: A file can contain multiple keys (stored in "key rings")
    /// </summary>
    private PgpSecretKey GetLastSecretKey(PgpSecretKeyRingBundle secretKeyRingBundle)
    {
        return (from PgpSecretKeyRing kRing in secretKeyRingBundle.GetKeyRings()
                select kRing.GetSecretKeys().Cast<PgpSecretKey>()
                                                .LastOrDefault(k => k.IsSigningKey))
                                                .LastOrDefault(key => key != null);
    }
