        DataTable dt = new DataTable();
        DataTable dtCopy = new DataTable();
        dt.Columns.Add("Test1");
        for (int counter = 0; counter < 10; counter++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = counter.ToString();
            dt.Rows.Add(dr);
        }
        dtCopy = dt.Copy();
        int counterLength = 10;
        for (int counter = 0; counter < counterLength; counter++)
        {
            if (Convert.ToInt32(dt.Rows[counter][0]) > 6)
            {
                dt.Rows[counter].Delete();
                counterLength--;
            }
        }
        dt.AcceptChanges();
