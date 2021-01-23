    //Assumes i is declared somewhere else 
    for (i ; i < smss.Count; i++)
    {
        if (smss[i].Attributes["body"].InnerText.Contains(searchText))
        {
            txtName.Text = smss[i].Attributes["body"].InnerText +
                           smss[i].Attributes["time"].Value;
            break;
        }
    }
