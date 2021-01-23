    void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
    {
        UltraGridBand band = e.Layout.Bands[0];
        band.ColHeadersVisible = false;
        ColumnsCollection columns = band.Columns;
    
        UltraGridGroup group0 = band.Groups.Add("group0");
        group0.Header.Caption = "";
        UltraGridGroup group1 = band.Groups.Add("group1");
        group1.Header.Caption = "Header 1";
        UltraGridGroup group2 = band.Groups.Add("group2");
        group2.Header.Caption = "Header 2";
    
        columns[0].Group = group0;
        columns[1].Group = group1;
        columns[2].Group = group1;
        columns[3].Group = group2;
        columns[4].Group = group2;
                
    }
