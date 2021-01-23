    foreach (DataRow dr in yourDataTable.Rows)
    {
        foreach(DataColumn col in yourDataTable.Columns)
        {
            try
            {
                if (dr[col].ToString().Contains("Mike"))
                {
                    //Save this one!
                }
            }
            catch
            { 
                //it was not a string, go on then.
            }
        }
    }
