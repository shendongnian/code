    for (int i = 0; i < dt.Rows.Count; i++)
    {
        row = dt.Rows[i];
        list[i].Link = row[0].ToString();// 
        list[i].Description = row[1].ToString();
        list[i].Title = row[2].ToString();
        list[i].Date = DateTime.Parse(row[3].ToString());
    }
