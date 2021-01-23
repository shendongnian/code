    private void grdPeople_InitializeRow(object sender, InitializeRowEventArgs e)
    {
        if (e.Row.Cells["NoSMS"].Value != null)
        {
            if (e.Row.Cells["NoSMS"].Value.ToString() == "True")
            {
                e.Row.Appearance = grdPeople.DisplayLayout.Appearances["disabled_row"];
                foreach(UltraGridCell c in e.Row.Cells)
                    c.SelectedAppearance = grdPeople.DisplayLayout.Appearances["disabled_row"];
            }
        }
    }
