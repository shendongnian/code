    public virtual int GetSqlValues(object[] values)
    {
        SqlStatistics statistics = null;
        int num3;
        try
        {
            statistics = SqlStatistics.StartTimer(this.Statistics);
            this.CheckDataIsReady();
            if (values == null)
            {
                throw ADP.ArgumentNull("values");
            }
            this.SetTimeout(this._defaultTimeoutMilliseconds);
            int num2 = (values.Length < this._metaData.visibleColumns) ? values.Length : this._metaData.visibleColumns;
            for (int i = 0; i < num2; i++)
            {
                values[this._metaData.indexMap[i]] = this.GetSqlValueInternal(i);
            }
            num3 = num2;
        }
        finally
        {
            SqlStatistics.StopTimer(statistics);
        }
        return num3;
    }
    
     
