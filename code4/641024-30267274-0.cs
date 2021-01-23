    public DirectoryEntry FindMatchingSID(Byte[] SIDBytes, String Win2KDNSDomainName)
    {
        using (DirectorySearcher Searcher = new DirectorySearcher("LDAP://" + Win2KDNSDomainName))
        {
            System.Text.StringBuilder SIDByteString = new System.Text.StringBuilder(SIDBytes.Length * 3);
        
            for (Int32 sidByteIndex = 0; sidByteIndex < SIDBytes.Length; sidByteIndex++)
                SIDByteString.AppendFormat("\\{0:x2}", SIDBytes[sidByteIndex]);
            
            Searcher.Filter = "(objectSid=" + SIDByteString.ToString() + ")";
            SearchResult result = Searcher.FindOne();
            if (result == null)
                throw new Exception("Unable to find an object using \"" + Searcher.Filter + "\".");
            else
                return result.GetDirectoryEntry();
        }
    }
