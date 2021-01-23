    SqlDataReader dr;
    DataTable dt = new DataTable();
    dt.Load(dr);
    int _RowCount = dt.Rows.Count;
    int inc = 0 ; 
    while (dr.Read())
    {
    inc = inc + 1;
    if(inc==_RowCount)
    //Without Comma
    else
    //With Comma
    }
