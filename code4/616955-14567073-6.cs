    [DirectoryProperty("vwBlobData")]
    public byte[] BlobData
    {
        get
        {
            if (ExtensionGet("vwBlobData").Length != 1)
                return null;
            return (byte[])ExtensionGet("vwBlobData")[0];
        }
        set
        {
            ((DirectoryEntry)this.GetUnderlyingObject())
                                 .Properties["vwBlobData"].Value = value;
        }
    }
