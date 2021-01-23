    void dg_BeginningEdit(object sender, BeginningEditEventArgs e)
    {
        IsInEditMode=true;
    }
    void dg_CellEditEnding(object sender, CellEditEndingEventArgs e)
    {
        IsInEditMode=false;
    }
