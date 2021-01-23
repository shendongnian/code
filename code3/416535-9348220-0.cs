    Dictionary<int, string> gPos = new Dictionary<int,string>();
    DataTable dtCopy = (grid.DataSource as DataView).Table.Copy();
    dtCopy.PrimaryKey = null;
    foreach(UltraGridColumn gCol in grid.DisplayLayout.Bands[0].Columns)
    {
        if(gCol.Hidden == true)
            dtCopy.Columns.Remove(gCol.Key);
        else
    	  gPos.Add(gCol.Header.VisiblePosition, gCol.Key);
    }
    var list = gPos.Keys.ToList();
    list.Sort();
    int realPos = 0;
    foreach (var key in list)
    {
        dtCopy.Columns[gPos[key]].SetOrdinal(realPos++);
    }
