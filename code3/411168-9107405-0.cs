    DataTable dt = CompareDataTables(dt1, dt2);
    ArrayList Errors = new ArrayList();
    for (int i = 0; i < d.Columns.Count; i++)
    {
        for (int j = 0; j < d.Rows.Count; j++)
        {
            if (dt1.Rows[j][i].ToString() != dt2.Rows[j][i].ToString())
                {
                    Errors.Add(j);
                    Errors.Add(i);
                    Errors.Add(dt1.Rows[j][i].ToString());
                    Errors.Add(dt2.Rows[j][i].ToString());
                }
         }
     }
    DataTable dtFinal = dt;
    for (int i = 0; i < Errors.Count; i += 4)
    {
        int ak = Int32.Parse(Errors[i].ToString());
        int bk = Int32.Parse(Errors[i + 1].ToString());
        dtFinal.Rows[ak][bk] = Errors[i + 2].ToString() + "/" + Errors[i + 3].ToString();
    }
