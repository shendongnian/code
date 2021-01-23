    private void gridMain_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
        CommonInitializeLayout(gridMain, e);
    }
    private void CommonInitializeLayout(UltraWinGrid grd, InitializeLayoutEventArgs e)
    {
       UltraGridBand b = e.Layout.Bands[0];
       // Now do the customization of the grid passed in, for example....
       b.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
       b.Override.AllowAddNew = AllowAddNew.No;
       b.Override.NullText = "(Not available)";
       b.Columns["CustName"].Header.Caption = "Customer Name";
       ....... etc ....
    }
    private void cmdMakeReport_Click(object sender, EventArgs e)
    {
        // This assignment will trigger the InitializeLayout event for the grdReport
        grdReport.DataSource = grdMain.DataSource;
        // Now the two grids have the same columns and the same data 
        
        // Start to hide the columns not desired in printing
        grdReport.DisplayLayout.Bands[0].Columns["CustID"].ExcludeFromColumnChooser =
                                                                 ExcludeFromColumnChooser.True 
        grdReport.DisplayLayout.Bands[0].Columns["CustID"].Hidden = true;
        // .... other columns to hide.....
        // Now print the grdReport
        ultraGridPrintDocument.Grid = grdReport;
        ultraGridPrintDocument.Print();
    }
    private void gridReport_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
        CommonInitializeLayout(griReport, e);
    }
