    StringBuilder tempText = new StringBuilder();
    foreach (Principal oResult in oPrincipalSearchResult)
    {
        myItems.Add(oResult.Name);
        tempText.Append(oResult.Name.ToString());
        tempText.Append(Environment.NewLine);
    }
    textBox1.Text = tempText.ToString();
