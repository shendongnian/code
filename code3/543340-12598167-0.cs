    foreach(DataRow r in ds.Tables[0].Rows)
    {
        foreach(DataColumn c in ds.Tables[0].Columns)
        {
            if(!r.IsNull(c))
            {
                var field = r[c].ToString().Trim();
                if (field.Length == 1)
                    r[c] = field.ToUpper();
                else
                    r[c] = char.ToUpper(field[0]) + field.Substring(1);
            }
        }
    }
