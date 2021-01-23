     MatchCollection matches = Regex.Matches(rtb.Text, @"^[a-m]{1}$");
     if (matches != null && matches.Count > 0)
     {
         foreach (Match m in matches)
         {
             rtb.Select(m.Index, m.Length);
             rtb.SelectionColor = Color.Blue;
         }
     }
