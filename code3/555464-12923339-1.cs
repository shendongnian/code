    var optionList = new List<ListItem>();
    
    for (var i = 0; i < 4; i++)
    {
      var newItem = new ListItem()
      {
          Value = count.ToString(),
          Text = string.Format("Option {1}", count.ToString());
      };
      optionList.Add(newItem);
    }
    
    Answers.DataSource = optionList;
    Answers.DataBind();
