    DataTable.SetNewRecordWorker(DataRow row, int proposedRecord, DataRowAction action, bool isInMerge, bool suppressEnsurePropertyChanged, int position, bool fireEvent, out Exception deferredException)
	{
		deferredException = (Exception) null;
		if (row.tempRecord != proposedRecord)
		{
		if (!this.inDataLoad)
		{
			row.CheckInTable();
			this.CheckNotModifying(row);
		}
		if (proposedRecord == row.newRecord)
		{
			if (!isInMerge)
			return;
			this.RaiseRowChanged((DataRowChangeEventArgs) null, row, action);
			return;
		}
		else
			row.tempRecord = proposedRecord;
		}
		DataRowChangeEventArgs args = (DataRowChangeEventArgs) null;
		try
		{
		row._action = action;
		args = this.RaiseRowChanging((DataRowChangeEventArgs) null, row, action, fireEvent);
		}
		catch
		{
		row.tempRecord = -1;
		throw;
		}
		finally
		{
		row._action = DataRowAction.Nothing;
		}
		row.tempRecord = -1;
		int record = row.newRecord;
		int num = proposedRecord != -1 ? proposedRecord : (row.RowState != DataRowState.Unchanged ? row.oldRecord : -1);
		if (action == DataRowAction.Add)
		{
		if (position == -1)
			this.Rows.ArrayAdd(row);
		else
			this.Rows.ArrayInsert(row, position);
		}
		List<DataRow> cachedRows = (List<DataRow>) null;
		if ((action == DataRowAction.Delete || action == DataRowAction.Change) && (this.dependentColumns != null && this.dependentColumns.Count > 0))
		{
		cachedRows = new List<DataRow>();
		for (int index = 0; index < this.ParentRelations.Count; ++index)
		{
			DataRelation relation = this.ParentRelations[index];
			if (relation.ChildTable == row.Table)
			cachedRows.InsertRange(cachedRows.Count, (IEnumerable<DataRow>) row.GetParentRows(relation));
		}
		for (int index = 0; index < this.ChildRelations.Count; ++index)
		{
			DataRelation relation = this.ChildRelations[index];
			if (relation.ParentTable == row.Table)
			cachedRows.InsertRange(cachedRows.Count, (IEnumerable<DataRow>) row.GetChildRows(relation));
		}
		}
		if (!suppressEnsurePropertyChanged && !row.HasPropertyChanged && (row.newRecord != proposedRecord && -1 != proposedRecord) && -1 != row.newRecord)
		{
		row.LastChangedColumn = (DataColumn) null;
		row.LastChangedColumn = (DataColumn) null;
		}
		if (this.LiveIndexes.Count != 0)
		{
		if (-1 == record && -1 != proposedRecord && (-1 != row.oldRecord && proposedRecord != row.oldRecord))
			record = row.oldRecord;
		DataViewRowState recordState1 = row.GetRecordState(record);
		DataViewRowState recordState2 = row.GetRecordState(num);
		row.newRecord = proposedRecord;
		if (proposedRecord != -1)
			this.recordManager[proposedRecord] = row;
		DataViewRowState recordState3 = row.GetRecordState(record);
		DataViewRowState recordState4 = row.GetRecordState(num);
		this.RecordStateChanged(record, recordState1, recordState3, num, recordState2, recordState4);
		}
		else
		{
		row.newRecord = proposedRecord;
		if (proposedRecord != -1)
			this.recordManager[proposedRecord] = row;
		}
		row.ResetLastChangedColumn();
		if (-1 != record && record != row.oldRecord && (record != row.tempRecord && record != row.newRecord) && row == this.recordManager[record])
		this.FreeRecord(ref record);
		if (row.RowState == DataRowState.Detached && row.rowID != -1L)
		this.RemoveRow(row, false);
		if (this.dependentColumns != null)
		{
		if (this.dependentColumns.Count > 0)
		{
			try
			{
			this.EvaluateExpressions(row, action, cachedRows);
			}
			catch (Exception ex)
			{
			if (action != DataRowAction.Add)
				throw ex;
			deferredException = ex;
			}
		}
		}
		try
		{
		if (!fireEvent)
			return;
		this.RaiseRowChanged(args, row, action);
		}
		catch (Exception ex)
		{
		if (!ADP.IsCatchableExceptionType(ex))
			throw;
		else
			ExceptionBuilder.TraceExceptionWithoutRethrow(ex);
		}
	}
