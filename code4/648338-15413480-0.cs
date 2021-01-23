    Translate t1 = new Translate() { IdSprache = 0 };
    Translate t2 = new Translate() { IdSprache = 3 };
    Translate t3 = new Translate() { IdSprache = 7 };
    DataTable dt = new DataTable();
    for (int i = 0; i < 10; i++)
        dt.Columns.Add(new DataColumn("C" + i, typeof(Translate)));
    for (int i = 0; i < 5; i++)
    {
        DataRow dr = dt.NewRow();
        dr[i] = new Translate() { IdSprache = i };
        dt.Rows.Add(dr);
    }
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (dt.Rows[i][j] as Translate != null)
                Console.Write("T");
            else
                Console.Write("N");
        }
        Console.WriteLine();
    }
