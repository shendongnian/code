    StringBuilder text = new StringBuilder();
    foreach (Principal oResult in oPrincipalSearchResult)
    {
        myItems.Add(oResult.Name);
        text.Append(oResult.Name);
        text.AppendLine();
    }
    
    textBox1.Text = text.ToString();
