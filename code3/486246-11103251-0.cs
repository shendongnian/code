    internal void Clear(bool clearAll)
    {
        if (clearAll) // true is sent from the Data Table call
        {
            for (int i = 0; i < this.recordCapacity; i++)
            {
                this.rows[i] = null;
            }
            int count = this.table.columnCollection.Count;
            for (int j = 0; j < count; j++)
            {
                DataColumn column = this.table.columnCollection[j];
                for (int k = 0; k < this.recordCapacity; k++)
                {
                    column.FreeRecord(k);
                }
            }
            this.lastFreeRecord = 0;
            this.freeRecordList.Clear();
        }
        else // False is sent from the DataRow Collection
        {
            this.freeRecordList.Capacity = this.freeRecordList.Count + this.table.Rows.Count;
            for (int m = 0; m < this.recordCapacity; m++)
            {
                if ((this.rows[m] != null) && (this.rows[m].rowID != -1))
                {
                    int record = m;
                    this.FreeRecord(ref record);
                }
            }
        }
    }
