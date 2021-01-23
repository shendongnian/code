    dgv.CellBeginEdit += dgv_CellBeginEdit;
    dgv.CellValidating += dgv_CellValidating;
    dgv.CellEndEdit += dgv_CellEndEdit;
    private void dgv_CellBeginEdit(Object sender, DataGridViewCellCancelEventArgs e)
    {
         //Here we save a current value of cell to some variable, that later we can compare with a new value
        //For example using of dgv.Tag property
        if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            this.dgv.Tag = this.dgv.CurrentCell.Value;
            //Or cast sender to DataGridView variable-> than this handler can be used in another datagridview
        }
    }
    private void dgv_CellValidating(Object sender, DataGridViewCellValidatingEventArgs e)
    {
        //Here you can add all kind of checks for new value
        //For exapmle simple compare with old value and check for be more than 0
        if(this.dgv.Tag = this.dgv.CurrentCell.Value)
            e.Cancel = true;    //Cancel changes of current cell
        //For example used Integer check
        int32 iTemp;
        if (Int32.TryParse(this.dgv.CurrentCell.Value, iTemp) = True && iTemp > 0)
        {
            //value is ok
        }
        else
        {
            e.Cancel = True;
        }
    }
    Private Sub dgvtest1_CellEndEdit(Object sender, DataGridViewCellEventArgs e)
    {
        //Because CellEndEdit event occurs after CellValidating event(if not cancelled)
        //Here you can update new value to database
    }
