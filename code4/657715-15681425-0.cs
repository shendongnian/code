    private void grdPeople_InitializeRow(object sender, InitializeRowEventArgs e)
    {
        if (e.Row.Cells["NoSMS"].Value != null)
        {
            if (e.Row.Cells["NoSMS"].Value.ToString() == "True")
            {
                e.Row.Appearance = e.Layout.Appearances["disabled_row"];
                foreach(UltraGridCell c in e.Row.Cells)
                    c.SelectedAppearance = e.Layout.Appearances["disabled_row"];
            }
        }
    }
