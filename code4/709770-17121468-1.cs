    void Main()
    {
    OnOpenFile();
    OnOpenFile();
    OnOpenFile();
    }
    	public string[] OnOpenFile()
    {
        string strReturn = null;
        string[] strFilename = null;
        System.Windows.Forms.OpenFileDialog fdlg = new System.Windows.Forms.OpenFileDialog();
        fdlg.Title = "Select an Excel file to Upload.";
    	//fdlg.Filter = filetype;
        fdlg.InitialDirectory = Path.GetTempPath();
        fdlg.RestoreDirectory = true;
        if (fdlg.ShowDialog() == DialogResult.OK) 
        {
            strFilename = fdlg.FileNames;
        }
        return strFilename;
    }
