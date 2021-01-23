    public DataSet DataSetStationId(DataSet yourDataSet) 
        {
            DataSet newDs = new DataSet();
            DataTable newDt = new DataTable();
            newDt.Columns.Add(new DataColumn("Station Id"));
            for (int i = 0; i < yourDataSet.Tables[0].Rows.Count; i++) 
            {
                newDt.Rows[i]["Station Id"] = yourDataSet.Tables[0].Rows[i]["Station Id"];
            }
            newDs.Tables.Add(newDt);
            return newDs;
        }
