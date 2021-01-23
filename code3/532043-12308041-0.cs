    private void gridMain_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
        CommonInitializeLayout(gridMain, e);
    }
    private void CommonInitializeLayout(UltraWinGrid grd, InitializeLayoutEventArgs e)
    {
       UltraGridBand b = e.Layout.Bands[0];
       // do your customization using the first band of columns present in the datasource
    }
    private void cmdMakeReport_Click(object sender, EventArgs e)
    {
        // This assignment will trigger the InitializeLayout event for the grdReport
        grdReport.DataSource = grdMain.DataSource;
        // Now the two grids have the same columns and data 
        
        // Start to hide the colomns not desired in printing
        grdReport.DisplayLayout.Bands[0].Columns["columnToHide"].ExcludeFromColumnChooser =
                                                                 ExcludeFromColumnChooser.True 
        grdReport.DisplayLayout.Bands[0].Columns["columnToHide"].Hidden = true;
        // .... other columns to hide.....
        // Now print the grdReport
        ultraGridPrintDocument.Grid = grdReport;
        ultraGridPrintDocument.Print();
    }
    private void gridReport_InitializeLayout(object sender, InitializeLayoutEventArgs e)
    {
        CommonInitializeLayout(griReport, e);
    }
