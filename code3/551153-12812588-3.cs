    int i = 0;
    while (i < DTTable2.Rows.Count)
    {
        if (DTTable2.Rows[i]["ItemID"].ToString() == DTTable1.Rows[0]["ItemID"].ToString())
            DTTable2.Rows.RemoveAt(i);
        else
            i++;
    }
