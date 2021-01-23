    public Task CmdLoadExcel()
    {
        // läd die excel datei
       string[] excelFiles = this.GetExcelFiles();
       ExcelLoader eloader = new ExcelLoader();
       var task = eloader.StartLoading(excelFiles);
       return task.ContinueWith(t =>
                {
                    foreach (DataSet elem in eloader.Tables)
                    {
                        this.ActivateItem(new ExcelViewModel(elem) { DisplayName = elem.DataSetName });
                    }
                });
     }
