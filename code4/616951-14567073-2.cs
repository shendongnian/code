           [DirectoryProperty("vwBlobData")]
            public byte[] BlobData
            {
                get
                {
                    if (ExtensionGet("vwEncryptedPassword").Length != 1)
                        return null;
                    return (byte[])ExtensionGet("vwEncryptedPassword")[0];
                }
        set
        {
            ((DirectoryEntry)this.GetUnderlyingObject())
                                 .Properties["vwEncryptedPassword"].Value = value;
        }
    }
