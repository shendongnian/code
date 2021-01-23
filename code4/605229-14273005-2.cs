    [NonSerialized]
    private HttpPostedFileBase _spreadSheetFile;
    public HttpPostedFileBase SpreadsheetFile {
        get { return _spreadSheetFile; } 
        set { _spreadSheetFile = value; }
    }
