    string password = "acd";
    StringBuilder sb = new StringBuilder();
    foreach (var val in password)
    {
        if (char.IsUpper(val))
            sb.Append("Capital " + val + " as in " + Letters.Where(r => r.Letter == val).FirstOrDefault().Word + Environment.NewLine);
        else
            sb.Append("Small " + val + " as in " + Letters.Where(r => r.Letter == val).FirstOrDefault().Word + Environment.NewLine);
    }
    string test = sb.ToString();
