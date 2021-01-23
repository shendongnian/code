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
            if(ExtensionGet("vwBlobData").Length == 0)
                this.ExtensionSet("vwBlobData", data); 
            else
                ((DirectoryEntry)this.GetUnderlyingObject())
                                     .Properties["vwBlobData"].Value = data;
        }
    }
