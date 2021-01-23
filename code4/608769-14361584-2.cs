    internal static int NameOrOidToAlgId(string oid, OidGroup oidGroup)
    {
        if (oid == null)
        {
            return 0x8004;
        }
        string str = CryptoConfig.MapNameToOID(oid, oidGroup);
        if (str == null)
        {
            str = oid;
        }
        int algIdFromOid = GetAlgIdFromOid(str, oidGroup);
        switch (algIdFromOid)
        {
            case 0:
            case -1:
                throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidOID"));
        }
        return algIdFromOid;
    }
