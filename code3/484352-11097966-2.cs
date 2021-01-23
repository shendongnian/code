    public HeatMapVisualisationDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt)
    	base()
    {
        _valueMin = info.GetSingle("valueMin");
        _valueMax = info.GetSingle("valueMax");
    
        System.Collections.ArrayList colNames = (System.Collections.ArrayList)info.GetValue("colNames", typeof(System.Collections.ArrayList));
        System.Collections.ArrayList colTypes = (System.Collections.ArrayList)info.GetValue("colTypes", typeof(System.Collections.ArrayList));
        System.Collections.ArrayList dataRows = (System.Collections.ArrayList)info.GetValue("dataRows", typeof(System.Collections.ArrayList));
    
        // Add columns
        for (int i = 0; i < colNames.Count; i++)
        {
            DataColumn col = new DataColumn(colNames[i].ToString(), Type.GetType(colTypes[i].ToString()));
            this.Columns.Add(col);
        }
    
        // Add rows
        for (int i = 0; i < dataRows.Count; i++)
        {
            DataRow row = this.Rows.Add((object[])dataRows[i]);
        }
    
        this.AcceptChanges();
    }
    public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt)
    {
        System.Collections.ArrayList colNames = new System.Collections.ArrayList();
        System.Collections.ArrayList colTypes = new System.Collections.ArrayList();
        System.Collections.ArrayList dataRows = new System.Collections.ArrayList();
    
        foreach (DataColumn col in this.Columns)
        {
            colNames.Add(col.ColumnName);
            colTypes.Add(col.DataType.FullName);
        }
    
        foreach (DataRow row in this.Rows)
        {
            dataRows.Add(row.ItemArray);
        }
    
        info.AddValue("colNames", colNames);
        info.AddValue("colTypes", colTypes);
        info.AddValue("dataRows", dataRows);
        info.AddValue("valueMin", _valueMin);
        info.AddValue("valueMax", _valueMax);
    }
