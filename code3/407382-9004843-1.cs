    for(int i=0; i<dt.Rows.Count; i++)
    {
      temp = dt.Rows[i].ItemArray[0].ToString();
    
    if (System.Text.RegularExpressions.Regex.IsMatch(temp, "A-", System.Text.RegularExpressions.RegexOptions.IgnoreCase) || System.Text.RegularExpressions.Regex.IsMatch(temp, "N6", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
       {
         dt.Rows.RemoveAt(i);
       }
     }
