        Dictionary<int, List<DataSet>> dict = new Dictionary<int, List<DataSet>>();
        foreach (var d in dict)
        {
            foreach (DataSet ds in d.Value)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    dt.RowChanged += new DataRowChangeEventHandler(dt_RowChanged);    
                }
            }
        }
