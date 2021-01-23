      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)         
      {
        string options = (HiddenField)e.Item.FindControl("hfAnswer")).Value;
        string type = ((HiddenField)e.Item.FindControl("hfType")).Value;
        Label lblquestion = ((Label)e.Item.FindControl("LblQuestion"));
        PlaceHolder phRow = (PlaceHolder)e.Item.FindControl("phRow");
        if (type == "Text")
        {
          TextBox txtAnswer = new TextBox();
          phRow.Controls.Add(txtAnswer);
        }
        else if (type == "Check")
        {
          CheckBoxList chklist = new CheckBoxList();
          chklist.RepeatDirection = RepeatDirection.Horizontal;
          chklist.Font.Italic = true;
          chklist.RepeatColumns = 4;
          foreach (string option in options.Split(','))
          {
            ListItem items = new ListItem();
            items.Text = option;
            items.Value = option; 
            chklist.Items.Add(items);
          }                   
          phRow.Controls.Add(chklist);
        }
        else
        {
          RadioButtonList rdblist = new RadioButtonList();
          rdblist.RepeatDirection = RepeatDirection.Horizontal;
          rdblist.Font.Italic = true;
          rdblist.RepeatColumns = 4;
          foreach (string option in options.Split(','))
          {
            ListItem items = new ListItem();
            items.Text = option;
            items.Value = option; 
            rdblist.Items.Add(items);
          }                   
          phRow.Controls.Add(rdblist);
        }
      }
    }
