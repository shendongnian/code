    DataTable dt3 = new DataTable();
    dt3.Columns.Add("termid");
    dt3.Columns.Add("faultid");
    int nr = 0;
    for (int i = 0; i < dtOutput.Rows.Count; i++)
    {
        bool found = false;
        for (int j = 0; j < dtOpenEvent.Rows.Count; j++)
        {
            if (dtOutput.Rows[i][0] == dtOpenEvent.Rows[j][0] 
                && dtOutput.Rows[i][1] == dtOpenEvent.Rows[j][1])
            {
                found = true;
                break;
            }
        }
        if (!found)
        {
            dt3.Rows.Add(dt3.NewRow());
            dt3.Rows[nr][0] = dtOutput.Rows[i][0];
            dt3.Rows[nr][1] = dtOutput.Rows[i][1];
            nr++;
        }
    }
