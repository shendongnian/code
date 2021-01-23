    //private members
    private int _errorCode;
    private string _errorMessage;
    private string _exMessage;
    private ArrayList _drives;
    private string[] _folders;
    private string[] _filePaths;
    #region Constructors
    //constructor 1
    public ReturnClass()
    {
    }
    //constructor 2
    public ReturnClass(int iErr, string sErrMsg, string ExMsg, ArrayList arrDrives, string[] sfolders, string[] sFilePaths)
    {
        ErrorCode = iErr;
        ErrorMessage = sErrMsg;
        ExMessage = ExMsg;
        Drives = arrDrives;
        Folders = sfolders;
        FilePaths = sFilePaths;
    }
    #endregion
    #region methods
    //Error Code
    [DataMember]
    public int ErrorCode
    {
        get { return this._errorCode; }
        set { this._errorCode = value; }
    }
    //error message
    [DataMember]
    public string ErrorMessage
    {
        get { return this._errorMessage; }
        set { this._errorMessage = value; }
    }
    //exception message
    [DataMember]
    public string ExMessage
    {
        get { return this._exMessage; }
        set { this._exMessage = value; }
    }
    //drives
    [DataMember]
    public ArrayList Drives
    {
        get { return this._drives; }
        set { this._drives = value; }
    }
    //folders
    [DataMember]
    public string[] Folders
    {
        get { return this._folders; }
        set { this._folders = value; }
    }
    //File Paths
    [DataMember]
    public string[] FilePaths
    {
        get { return this._filePaths; }
        set { this._filePaths = value; }
    }
    #endregion
