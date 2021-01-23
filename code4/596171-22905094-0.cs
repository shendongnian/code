    void gridView1_ShownEditor(object sender, EventArgs e)
    {
        ColumnView view = (ColumnView)sender;        
        view.ActiveEditor.Properties.ReadOnly = view.FocusedRowHandle == 0;
    }
