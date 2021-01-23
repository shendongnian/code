    private Boolean bRbtnCurrentValue 
    private Int32 iRowRadioBtn = 1
    private Datagrid dg //Only for this exapmle
    //In Event dg_CellBeginEdit
    {
        //Here we stored current value to variable
        if (this.dgv.CurrentCell.ColumnIndex = this.iColumnRadioBtn)
            this.bRbtnCurrentValue = this.dgv
    }
    //In Event dg_CellEndEdit
    {
        //Here we update if value changed
        Boolean bNewValue = this.dgv.CurrentCell.Value
        if (this.dgv.CurrentCell.RowIndex = this.iRowRadioBtn)
        {
            if(bNewValue=False)
                this.dg.CurrentCell.Value=this.bRbtnCurrentValue
            else
                //Here jo actions when value changed(database update etc.)
        }	
    }
    //Event dgv_ CurrentCellDirtyStateChanged
    {
        if(this.dg.CurrentCell.RowIndex = this.iRowRadioBtn) andalso (dg.IsCurrentCellDirty = True)
        {
            foreach(DataGridColumn dgc In dg.Columns)
            {
                If (dgc.Index = dgc.CurrentColumn.Index)
                    If (dg.CurrentCell.Value = True)
                        dg.CancelEdit() //True to False cannot be changed
                else
                    If (dgc.Cells(dg.CurrentCell.ColumnIndex).Value=True)
                        dgc.Cells(dg.CurrentCell.ColumnIndex).Value = False
            }
        }
    }
