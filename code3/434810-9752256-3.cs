    for (int i = 0; i < dt.Rows.Count; i++)
    {
        row = dt.Rows[i];
        list[i].Link = row[0].ToString();// 
        list[i].Description = row[1].ToString();
        list[i].Title = row[2].ToString();
        list[i].Date = ToDateTime(row[3].ToString());
    }
    public static DateTime? ToDateTime(string value)
    {
        DateTime result;
    
        if (DateTime.TryParse(value, out result))
        {
            return result;
        }
    
        return null;
    }
