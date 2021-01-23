    using (DSA dsaPublicPrivate = new DSACng(2048))
    using (DSA dsaPublic = new DSACng())
    {
        dsaPublic.ImportParameters(dsaPublicPrivate.ExportParameters(false));
        byte[] signature = dsaPublicPrivate.SignData(data, HashAlgorithmName.SHA256);
        bool isValid = dsaPublic.VerifyData(data, signature, HashAlgorithmName.SHA256);
        ...
    }
