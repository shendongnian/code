    StringBuilder sb = new StringBuilder();
    sb.Append("Name");
    sb.Append(",");
    sb.Append("Account Price");
    sb.Append(System.Environment.NewLine);
    foreach (Customer c in customers)
    {
        sb.Append(c.Name);
        sb.Append(",");
        sb.Append(c.AccountPrice);
        sb.Append(System.Environment.NewLine);
    }
     string csv = sb.ToString();
