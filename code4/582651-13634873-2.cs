    CBFsqldataDataContext conn = new  CBFsqldataDataContext();
    List<spTotalRevByZipResult> sptotalrevbyzipresult = (from s in conn.spTotalRevByZip() 
                                                         select s).ToList();
    ZipGrid.Series[0].ItemsSource = sptotalrevbyzipresult;
    ZipGrid.Series[0].ValueBinding = 
    new Telerik.Windows.Controls.ChartView.GenericDataPointBinding<DataRow, double>() 
    {
        ValueSelector = r => (double)r["subTotal"]
    };
    ZipGrid.Series[0].CategoryBinding = 
    new Telerik.Windows.Controls.ChartView.GenericDataPointBinding<DataRow, double>() 
    {
        ValueSelector = r => (double)r["custzip"]
    };
