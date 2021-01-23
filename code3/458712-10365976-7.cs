    DataTable.InsertRow(DataRow row, long proposedID, int pos, bool fireEvent)
    {
        Exception deferredException = (Exception) null;
        if (row == null)
            throw ExceptionBuilder.ArgumentNull("row");
        if (row.Table != this)
            throw ExceptionBuilder.RowAlreadyInOtherCollection();
        if (row.rowID != -1L)
            throw ExceptionBuilder.RowAlreadyInTheCollection();
        row.BeginEdit();
        int proposedRecord = row.tempRecord;
        row.tempRecord = -1;
        if (proposedID == -1L)
            proposedID = this.nextRowID;
        bool flag;
        if (flag = this.nextRowID <= proposedID)
            this.nextRowID = checked (proposedID + 1L);
        try
        {
            try
            {
                row.rowID = proposedID;
                this.SetNewRecordWorker(row, proposedRecord, DataRowAction.Add, false, false, pos, fireEvent, out deferredException);
            }
            catch
            {
                if (flag && this.nextRowID == proposedID + 1L)
                    this.nextRowID = proposedID;
                row.rowID = -1L;
                row.tempRecord = proposedRecord;
                throw;
            }
            if (deferredException != null)
                throw deferredException;
            if (!this.EnforceConstraints || this.inLoad)
                return;
            int count = this.columnCollection.Count;
            for (int index = 0; index < count; ++index)
            {
                DataColumn dataColumn = this.columnCollection[index];
                if (dataColumn.Computed)
                    dataColumn.CheckColumnConstraint(row, DataRowAction.Add);
            }
        }
        finally
        {
            row.ResetLastChangedColumn();
        }
    }
