    while (results.Read())
    {
        if (String.isNullOrEmpty(txt.Text))
        {
            txt.Text = results["TEXT_CONTENT"].ToString();
        }
        ListItem newItem = new ListItem();
        newItem.Text = results["TEXT_CONTENT"].ToString();
        newItem.Value = results["ID"].ToString();
   }
