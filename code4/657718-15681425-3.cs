    private void grdPeople_InitializeRow(object sender, InitializeRowEventArgs e)
    {
        UltraGridColumn c = e.Row.Band.Columns["NoSMS"];
        object o = e.Row.GetCellValue(c) ?? false;
        bool noSMS = Convert.ToBoolean(o);
 
        if (noSMS)
        {
            e.Row.Appearance = grdPeople.DisplayLayout.Appearances["disabled_row"];
            foreach(UltraGridCell c in e.Row.Cells)
                c.SelectedAppearance = grdPeople.DisplayLayout.Appearances["disabled_row"];
        }
    }
