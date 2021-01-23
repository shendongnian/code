    /// <summary>
    /// A value representing the specific type of error returned by Facebook.
    /// </summary>
    public enum ErrorType
    {
        ///<summary>
        ///</summary>
        Unknown = 1,
        ///<summary>
        ///</summary>
        ServiceUnavailable = 2,
        ///<summary>
        ///</summary>
        RequestLimit = 4,
        ///<summary>
        ///</summary>
        Timeout = 102,
        ///<summary>
        ///</summary>
        Signing = 104,
        ///<summary>
        ///</summary>
        InvalidUser = 110,
        ///<summary>
        ///</summary>
        InvalidAlbum = 120,
        ///<summary>
        ///</summary>
        UserNotVisible = 210,
        ///<summary>
        ///</summary>
        AlbumNotVisible = 220,
        ///<summary>
        ///</summary>
        PhotoNotVIsible = 221,
        ///<summary>
        ///</summary>
        InvaldFQLSyntax = 601
    }
