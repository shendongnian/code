    if (sslPolicyErrors == SslPolicyErrors.None)
    {
        var apiCertHash = new byte[] { 0x79, 0x04, 0x15, 0xC5, 0xC4, 0xF1, 0x6A, 0xA7, 0xC9, 0x12, 0xBB, 0x23, 0xED, 0x5A, 0x60, 0xA7, 0x92, 0xA8, 0xD5, 0x94 };
        if(chain.ChainElements.Count > 0)
        {
            //Not 100% if the root is first or last in the array. Don't have the program running to check.
            var certHash = chain.ChainElements[chain.ChainElements.Count - 1].Certificate.GetCertHash();
            if (certHash.Length == apiCertHash.Length)
            {
                for (var idx = 0; idx < certHash.Length; idx++)
                {
                    if (certHash[idx] == apiCertHash[idx])
                    {
                        return true;
                    }
                }
            }
        }
    }
