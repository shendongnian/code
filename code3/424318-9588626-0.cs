    int visibleColumns = 20;// columns that are in data grid view
    string[] headers;// headers for all desired columns 
    DataGridViewColumn[] columns;
    HScrollBar hbar = new HScrollBar();
    public Constructor(){
        ...
        int sizeDesired = 15000;
        int size = Math.Min(sizeDesired, visibleColumns);
        columns = new DataGridViewColumn[size];
        headers = new string[sizeDesired];
        for (int i = 0; i < size; i++)
        {
            columns[i] = new DataGridViewTextBoxColumn();
            columns[i].Name = "col" + i;
            columns[i].HeaderText = "col" + i;
            columns[i].FillWeight = 0.00001f;
        }
        for (int i = 0; i < sizeDesired;i++ )
        {
            headers[i] = "col" + i;
        }
        if (sizeDesired > size)
        {
            hbar.Maximum = sizeDesired - size;
            hbar.Minimum = 0;
            hbar.Value = 0;
        }
        hbar.Scroll += hbar_Scroll;
        ...
    }
    
    void hbar_Scroll(object sender, ScrollEventArgs e)
    {
        for (int i = 0; i < datagridview.ColumnCount; i++)
        {
            datagridview.Columns[i].HeaderText = headers[i + e.NewValue];
        }
    }
