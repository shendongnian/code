    IExcelDataReader iExcelDataReader = null;
    FileInfo fileInfo = new FileInfo(FpdUnConLoanUpload.PostedFile.FileName);
    string file = fileInfo.Name;
    if (file.Split('.')[1].Equals("xls"))
    {
        iExcelDataReader = ExcelReaderFactory.CreateBinaryReader(oStream);
    }
    else if (file.Split('.')[1].Equals("xlsx"))
    {
        iExcelDataReader = ExcelReaderFactory.CreateOpenXmlReader(oStream);
    }
    iExcelDataReader.IsFirstRowAsColumnNames = true;
    DataSet dsUnUpdated = new DataSet();
    dsUnUpdated = iExcelDataReader.AsDataSet();
    iExcelDataReader.Close();
    if (dsUnUpdated != null)
    {
    }
    else
    {
        lblCmnMesage.Text = "No Data Found In The Excel Sheet!";
    }
