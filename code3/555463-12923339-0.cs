    var optionList = new List<ListItem>();
    
    for (int count = 1; count < 5; ++count)
    {
      var newItem = new ListItem();
    
      newItem.Value = count.ToString();
      newItem.Text = "Option " + count.ToString();
    
      optionList.Add(newItem);
    }
    
    Answers.DataSource = optionList;
    Answers.DataBind();
