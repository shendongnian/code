    void MyDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == ColumnComment.Index) {
            object data = Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if((data != null) && (!CommentIsValid(data.ToString()))){
                CurrentCell = Rows[e.RowIndex].Cells[e.ColumnIndex];
                BeginEdit(true);
    
                // My notification method
                isInvalidState = OnNotification(
                    String.Format("Comment `{0}` contains invalid characters));
                if (isInvalidState)
                    invalidCell = MyDataGridView[e.RowIndex, e.ColumnIndex];
                return;
            }
        }
    }
