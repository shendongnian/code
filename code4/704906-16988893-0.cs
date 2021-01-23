    //First before loading data
    private void form_Load(object sender, EventArgs e){
       dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
       //Fill your dataGridView here
       //.........
       //.........
       int w = dataGridView.Columns[0].Width;
       //reset to None
       dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
       dataGridView.Columns[0].Width = w;
    }
    //Now for CellBeginEdit and CellEndEdit
    private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
    private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int w = dataGridView.Columns[0].Width;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView.Columns[0].Width = w;
        }
